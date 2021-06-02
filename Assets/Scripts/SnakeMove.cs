using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(SnakeInput))]
public class SnakeMove : MonoBehaviour
{
    private enum SnakeState { Idle,Crouch,Run,Walk,Jump,Equip }

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
    public event Action<bool> onShootEvent;
    public event Action<bool,Item> onEquipEvent;
    public event Action onIdleEvent;

    private int equipCounter;
    private bool isAnimEquipped;
    private bool isGunEquipped;
    private SnakeInventory inv;
    private Item equippedItem;

    private void Start()
    {
        onIdleEvent += Idle;
        onWalkEvent += Walk;
        onRunEvent += Run;
        onCrouchEvent += Crouch;
        onJumpEvent += Jump;
        onShootEvent += Shoot;
        onEquipEvent += Equip;



        _snakeInput = GetComponent<SnakeInput>();
        snakestate = SnakeState.Idle;
        rb = GetComponent<Rigidbody>();
        inv = GetComponent<SnakeInventory>();
        inv.onInventoryChange += unEquip;
        
    }
    private void Update()
    {
        doesIdle();
        doesMove();
        doesJump();
        doesCrouch();
        doesRun();
        doesEquip();
        doesShoot();

        
  
    }
    #region
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
        if (_snakeInput.sprintInput) {
            onRunEvent?.Invoke(dir);
            return;
        }
        onWalkEvent?.Invoke(dir);
        
        
    }
    void doesJump()
    {
       snakestate = SnakeState.Jump;
       onJumpEvent?.Invoke(_snakeInput.jumpInput);
       
    }
    void doesCrouch()
    {
       snakestate = SnakeState.Crouch;
       onCrouchEvent?.Invoke(_snakeInput.crouchInput);
    }

    void doesRun()
    {
        
        bool isRun = _snakeInput.sprintInput;
        snakestate = SnakeState.Run;
    }
    void doesEquip()
    {
        if (!isGunEquipped)
        {
            onEquipEvent?.Invoke(false,equippedItem);

            return;
        }

        if (_snakeInput.equipInput )
        {
            equipCounter++;

            if (equipCounter %2 == 1)
            {
                snakestate = SnakeState.Equip;
                isAnimEquipped = true;
                onEquipEvent?.Invoke(_snakeInput.equipInput,equippedItem);
            }
            else
            {
                snakestate = SnakeState.Idle;
                isAnimEquipped = false;
                onEquipEvent?.Invoke(!_snakeInput.equipInput,equippedItem);
            }
           
        }
    }
    void doesShoot()
    {
        if (isAnimEquipped )
        {

            Debug.Log("BAmBAM");
            onShootEvent?.Invoke(_snakeInput.actionInput);
        }
        
    }

    void Walk(Vector3 dir)
    {
        if (dir.magnitude > 1)
        {
            onRunEvent.Invoke(dir);
            return;
        }
        snakestate = SnakeState.Walk;
        Debug.Log("Walk");
        float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, _smoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0f) * Vector3.forward;
        controller.Move(moveDir.normalized * walkSpeed * Time.deltaTime);
    }
    void Run(Vector3 dir)
    {
        snakestate = SnakeState.Run;
        Debug.Log("Run");
        float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, _smoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0f) * Vector3.forward;
        controller.Move(moveDir.normalized * RunSpeed * Time.deltaTime);

        if (_snakeInput.jumpInput) onJumpEvent?.Invoke(_snakeInput.jumpInput);
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
    void Equip(bool isEquip,Item item)
    {
        Debug.Log("equip");
    }
    void Shoot(bool doesShoot)
    {
        Debug.Log("Idlee");
    }
    #endregion

    void unEquip(Item i1, Item i2, Item i3)
    {
        isGunEquipped = i1.icon == null ? false : true;
        equippedItem = i1;
    }

}
