using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    public ChaseState chaseState;
    public bool canSeeSnake;

    void Start()
    {
        
        
    }
    public override State RunState()
    {
        if (canSeeSnake)
        {
            return chaseState;
        }
        return this;
    }
}
