using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDBlendTree : MonoBehaviour
{
    Animator anim;

    float velX = 0;
    float velZ = 0;

    public float acceleration = 2f;
    public float decelaration = 2f;

    public float maxWalkVel = 0.5f;
    public float maxRunVel = 2f;
    float currentRunVel = 0;


    bool forwardPressed;
    bool backPressed;
    bool rightPressed;
    bool leftPressed;
    bool runPressed;

    int VelZHash;
    int VelXHash;
    void Start()
    {
        anim = GetComponent<Animator>();

        VelZHash = Animator.StringToHash("Velocity_Z");
        VelXHash = Animator.StringToHash("Velocity_X");
    }

    void changeVelocity(bool forwardPressed, bool leftPressed, bool rightPressd, bool runPressed, float currentRunVel)
    {
        if (forwardPressed && velZ < currentRunVel)
        {
            velZ += Time.deltaTime * acceleration;
        }
        if (backPressed && velZ > -currentRunVel)
        {
            velZ -= Time.deltaTime * acceleration;
        }

        if (leftPressed && velX > -currentRunVel)
        {
            velX -= Time.deltaTime * acceleration;
        }
        if (rightPressed && velX < currentRunVel)
        {
            velX += Time.deltaTime * acceleration;
        }

        if (!forwardPressed && velZ > 0.0f)
        {
            velZ -= Time.deltaTime * decelaration;
        }
        if (!backPressed && velZ < 0.0f)
        {
            velZ += Time.deltaTime * decelaration;
        }
        if (!leftPressed && velX < 0f)
        {
            velX += Time.deltaTime * decelaration;
        }
        if (!rightPressed && velX > 0f)
        {
            velX -= Time.deltaTime * decelaration;
        }
    }

    void lockResetVel(bool forwardPressed, bool leftPressed, bool rightPressd, bool runPressed, float currentRunVel)
    {

        if (!forwardPressed && !backPressed && velZ != 0 && (velZ > -0.05f && velZ < 0.05f))
        {
            velZ = 0;
        }
        if (!leftPressed && !rightPressed && velX != 0 && (velX > -0.05f && velX < 0.05f))
        {
            velX = 0;
        }
        if (forwardPressed && runPressed && velZ > currentRunVel)
        {
            velZ = currentRunVel;

        }
        else if (forwardPressed && velZ > currentRunVel)
        {
            velZ -= Time.deltaTime * decelaration;

            if (velZ > currentRunVel && velZ < (currentRunVel + 0.05))
            {
                velZ = currentRunVel;
            }

        }
        else if (forwardPressed && velZ < currentRunVel && velZ > (currentRunVel - 0.05f))
        {
            velZ = currentRunVel;
        }
    }
    // Update is called once per frame
    void Update()
    {
        forwardPressed = Input.GetKey(KeyCode.W);
        backPressed = Input.GetKey(KeyCode.S);
        leftPressed = Input.GetKey(KeyCode.A);
        rightPressed = Input.GetKey(KeyCode.D);
        runPressed = Input.GetKey(KeyCode.LeftShift);

        currentRunVel = runPressed ? maxRunVel : maxWalkVel;

        changeVelocity(forwardPressed, leftPressed, rightPressed, runPressed, currentRunVel);
        lockResetVel(forwardPressed, leftPressed, rightPressed, runPressed, currentRunVel);

        anim.SetFloat(VelZHash, velZ);
        anim.SetFloat(VelXHash, velX);
    }
}
