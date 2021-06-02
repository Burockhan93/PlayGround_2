using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeInput : MonoBehaviour
{
    public Vector3 movementInput {get; private set;}
    public bool jumpInput { get; private set; }

    public bool crouchInput { get; private set; }

    public bool sprintInput { get; private set; }

    public float scrollInput { get; private set; }

    public bool dropInput { get; private set; }
    public bool actionInput { get; private set; }
    public bool equipInput { get; private set; }


    private void Update()
    {
        movementInput = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        jumpInput = Input.GetKeyDown(KeyCode.Space);
        crouchInput = Input.GetKey(KeyCode.C);
        sprintInput = Input.GetKey(KeyCode.LeftShift);
        scrollInput = Input.mouseScrollDelta.y;
        dropInput = Input.GetKey(KeyCode.G);
        actionInput = Input.GetMouseButton(0);
        equipInput = Input.GetMouseButtonDown(1);

        Debug.Log("Crouch: " + crouchInput);
        Debug.Log("Jump: " + jumpInput);
    }
}
