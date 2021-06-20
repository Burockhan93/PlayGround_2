using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class charMovement : MonoBehaviour
{
    #region
    //CharacterController cc;
    //bool isGrounded;
    //void Start()
    //{
    //    cc = GetComponent<CharacterController>();

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    isGrounded = cc.isGrounded;

    //    if (!isGrounded)
    //    {
    //        cc.Move(Vector3.forward * Time.deltaTime);
    //    }


    //    Debug.Log(cc.isGrounded);
    //}
    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.rigidbody != null)
    //    {
    //        CollisionOnOff();
    //        Rigidbody rb = hit.rigidbody;
    //        rb.AddExplosionForce(10f, hit.transform.position, 5f);
    //    }

    //}

    //void CollisionOnOff()
    //{
    //    if (cc.detectCollisions == false) {

    //        cc.detectCollisions = true;
    //        return;
    //    }
    //    cc.detectCollisions = false;
    //    Invoke("CollisionOnOff", 1);

    //}
    #endregion

    NewControls controller;
    CharacterController character;
    Animator anim;

    Vector2 movementInput;
    Vector2 lookInput;
    Vector3 movement;
    Vector3 Runmovement;
    Vector2 LookPos;
    Vector3 realMov;

    bool isMove;
    bool isJump;
    bool isRun;

    int isWalkingHash;
    int isRunHash;
    int isJumpHash;

    
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        character = GetComponent<CharacterController>();



        controller = new NewControls();
        isWalkingHash = Animator.StringToHash("isWalk");
        isRunHash =  Animator.StringToHash("isRun");
        isJumpHash = Animator.StringToHash("isJump");


        controller.CharacterContol.Move.started += onMoveInput;
        controller.CharacterContol.Move.canceled += onMoveInput;
        controller.CharacterContol.Move.performed += onMoveInput;
        controller.CharacterContol.Look.started += onLookInput;
        controller.CharacterContol.Look.canceled += onLookInput;
        controller.CharacterContol.Look.performed += onLookInput;
        controller.CharacterContol.Run.started += onRun;
        controller.CharacterContol.Run.canceled += onRun;
        controller.CharacterContol.Jump.started += onJump;

    }
    void onRun(InputAction.CallbackContext context)
    {
        isRun = context.ReadValueAsButton();
    }
    void onJump(InputAction.CallbackContext context)
    {

    }

    void onMoveInput(InputAction.CallbackContext context) 
    {
         movementInput = context.ReadValue<Vector2>();
         //Debug.Log(movementInput);
         movement.x = movementInput.x;
         movement.z = movementInput.y;//gamepadde 2 axis var

        Runmovement.x = movementInput.x*3;
        Runmovement.z = movementInput.y*3;//gamepadde 2 axis var

        isMove = movementInput.y != 0 || movementInput.x != 0;
    }
    void onLookInput(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
        //LookPos.x = -lookInput.y;
        LookPos.y = -lookInput.x;

    }
    void handleLook()
    {
        LookPos.x += lookInput.x;
        //LookPos.x = lookInput.y;

        
    }
    void handleRotation()
    {
        Vector3 postionToLookAt;
        postionToLookAt.x = movement.x;
        postionToLookAt.y = 0;
        postionToLookAt.z = movement.z;

        Quaternion currntRot = transform.rotation;
        if (isMove)//Elini cekince geri eski haline dönmemei icin
        {
            Quaternion targetRot = Quaternion.LookRotation(postionToLookAt);
            transform.rotation = Quaternion.Slerp(currntRot, targetRot, 0.01f);
        }
        

    }
    private void Update()
    {
        //transform.Rotate(new Vector3(0f, lookInput.x, 0f), Space.Self);
        handleRotation();
        
        //transform.Rotate(LookPos, Space.World);
        //handleLook();
        handleAnim();
        handleGravity();

        if (isRun)
        {
            character.Move(Runmovement * Time.deltaTime * 2);
        }
        else
        {
            character.Move(movement * Time.deltaTime * 2);
        }
    }
    void handleGravity()
    {
        if (character.isGrounded)
        {
            float grv = -0.05f;
            movement.y = grv;
            Runmovement.y = grv;
        }
        else
        {
            float grv = -8f;
            movement.y += grv;
            Runmovement.y += grv;
        }
    }

    void handleAnim()
    {
        bool isWalking = anim.GetBool("isWalk");
        bool isRunning = anim.GetBool("isRun");
        bool isJump = anim.GetBool("isJump");

        if (isMove && !isWalking)
        {
            anim.SetBool("isWalk", true);
        }else if (!isMove && isWalking)
        {
            anim.SetBool("isWalk", false);
        }
        if ((isMove && isRun) && !isRunning)
        {
            anim.SetBool(isRunHash, true);
        }else if((!isMove || !isRun) && isRunning)
        {
            anim.SetBool(isRunHash, false);
        }

    }
    private void OnEnable()
    {
        controller.CharacterContol.Enable();
    }
    private void OnDisable()
    {
        controller.CharacterContol.Disable();
    }
}
