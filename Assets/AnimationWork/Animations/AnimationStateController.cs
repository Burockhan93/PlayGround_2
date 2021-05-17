using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator anim;
    bool runPressed;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //runPressed = Input.GetKey(KeyCode.LeftShift);
        anim.SetBool("isWalking", Input.GetKey("w"));
        anim.SetBool("isRunning", Input.GetKey(KeyCode.LeftShift));


    }
}
