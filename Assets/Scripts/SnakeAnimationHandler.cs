using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAnimationHandler : MonoBehaviour
{
    private Animator _anim;
    private SnakeMove _snakeMove;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _snakeMove = GetComponent<SnakeMove>();

    }

    private void Start()
    {
        _snakeMove.onIdleEvent += Idle;
        _snakeMove.onWalkEvent += Walk;
        _snakeMove.onRunEvent += Run;
        _snakeMove.onCrouchEvent += Crouch;
        _snakeMove.onJumpEvent += Jump;
    }
    void Walk(Vector3 dir)
    {
        _anim.SetFloat("Walk", dir.magnitude);
    }
    void Run(Vector3 dir)
    {
        _anim.SetFloat("Walk", dir.magnitude);
    }
    void Crouch(bool isCrouch)
    {
        _anim.SetBool("Crouch", isCrouch);
        
    }
    void Jump(bool isJump)
    {
        _anim.SetBool("Jump", isJump);
       
    }
    void Idle()
    {
        _anim.SetFloat("Walk", 0);
    }
}
