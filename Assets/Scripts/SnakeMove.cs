using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(SnakeInput))]
public class SnakeMove : MonoBehaviour
{
    private enum SnakeState { Idle,Crouch,Run,Walk,Jump }

    private SnakeState snakestate;
    private SnakeInput _snakeInput;
    public CharacterController controller;
    private Rigidbody rb;
    public Transform cam;

    public float walkSpeed;
    public float RunSpeed;

    private float _smoothTime = 0.1f;
    public float turnSmoothVelocity;


    public event Action<Vector3> onWalkEvent;
    public event Action<Vector3> onRunEvent;
    public event Action<bool> onCrouchEvent;
    public event Action<bool> onJumpEvent;
    public event Action onIdleEvent;

    private void Start()
    {
        onIdleEvent += Idle;
        onWalkEvent += Walk;
        onRunEvent += Run;
        onCrouchEvent += Crouch;
        onJumpEvent += Jump;


        _snakeInput = GetComponent<SnakeInput>();
        snakestate = SnakeState.Idle;
        rb = GetComponent<Rigidbody>();
        
    }
    private void Update()
    {
        Debug.Log(controller.isGrounded);

        doesIdle();
        doesMove();
        doesJump();
        doesCrouch();
        doesRun();

       
    }

    private void doesIdle()
    {
        if (_snakeInput.movementInput.magnitude < 0.1 && !_snakeInput.jumpInput &&
            !_snakeInput.crouchInput && !_snakeInput.sprintInput)
        {
            snakestate = SnakeState.Idle;
            onIdleEvent?.Invoke();
        }
    }
    private void doesMove()
    {
        Vector3 dir = _snakeInput.movementInput;
        if (dir.magnitude < 0.1) return;
        if (_snakeInput.sprintInput)
        {
            snakestate = SnakeState.Run;
            onRunEvent?.Invoke(dir*2);
            return;
        }
        snakestate = SnakeState.Walk;
        onWalkEvent?.Invoke(dir);
        
    }
    void doesJump()
    {
        if (_snakeInput.jumpInput)
        {
            snakestate = SnakeState.Jump;
            onJumpEvent?.Invoke(_snakeInput.jumpInput);
        }
    }
    void doesCrouch()
    {
        if ( _snakeInput.crouchInput)
        {
            snakestate = SnakeState.Crouch;
            onCrouchEvent?.Invoke(_snakeInput.crouchInput);
        }
    }

    void doesRun()
    {
        
        bool isRun = _snakeInput.sprintInput;
        snakestate = SnakeState.Run;
    }

    void Walk(Vector3 dir)
    {
        if (dir.magnitude > 1)
        {
            onRunEvent.Invoke(dir);
            return;
        }
        Debug.Log("Walk");
        float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, _smoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0f) * Vector3.forward;
        controller.Move(moveDir.normalized * walkSpeed * Time.deltaTime);
    }
    void Run(Vector3 dir)
    {
        Debug.Log("Run");
        float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, _smoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0f) * Vector3.forward;
        controller.Move(moveDir.normalized * RunSpeed * Time.deltaTime);
    }
    void Crouch( bool isCrouch)
    {
        Debug.Log("crouch");
    }
    void Jump(bool isJump)
    {
        Debug.Log("jump");
    }
    void Idle()
    {
        Debug.Log("Idlee");
    }
}
