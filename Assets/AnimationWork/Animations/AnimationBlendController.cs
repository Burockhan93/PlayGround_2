using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBlendController : MonoBehaviour
{
    Animator anim;
    float velocity = 0;
    public float accelaration = 0.1f;
    public float deceleration = 0.5f;
    int velocityHash;
    void Start()
    {
        anim = GetComponent<Animator>();
        velocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        if (forwardPressed && velocity <1.0f)
        {
            velocity += Time.deltaTime * accelaration;
        }
        if (!forwardPressed && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * deceleration;
        }
        if (!forwardPressed && velocity < .0f)
        {
            velocity = 0f;
        }

        anim.SetFloat(velocityHash, velocity);
    }
}
