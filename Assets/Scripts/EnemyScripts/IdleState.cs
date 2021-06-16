using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public ChaseState chaseState;
    public bool canSeeSnake ;

    private float distance;
    private StateManager stateManager;
    private SimpleEnemy simpleEnemy;
    
    private void Start()
    {
        chaseState = GetComponent<ChaseState>();
        stateManager = GetComponent<StateManager>();
        simpleEnemy = GetComponent<SimpleEnemy>();

    }
    public override State RunState()
    {
        if (canSeeSnake)
        {
            return chaseState;
        }
        return this;
    }

    private void Update()
    {
        distance = stateManager.distance;

        Debug.Log("DIstance: " + distance);
        if (distance < 4)
        {
            canSeeSnake = true;
        }
        else
        {
            simpleEnemy.Move();
            canSeeSnake = false;
        }
    }
}
