using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeInput : MonoBehaviour
{
    public Vector3 movementInput {get; private set;}
    public bool jumpInput { get; private set; }

    public bool crouchInput { get; private set; }

    public bool sprintInput { get; private set; }

    private void Update()
    {
        movementInput = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        jumpInput = Input.GetKeyDown(KeyCode.Space);
        crouchInput = Input.GetKey(KeyCode.C);
        sprintInput = Input.GetKey(KeyCode.LeftShift);

        Debug.Log("Crouch: " + crouchInput);
        Debug.Log("Jump: " + jumpInput);
    }
}
