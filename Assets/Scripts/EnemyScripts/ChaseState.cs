using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public KillState killState;
    public bool inRange;

    private float distance;
    private StateManager stateManager;


    private void Start()
    {
        killState = GetComponent<KillState>();
        stateManager = GetComponent<StateManager>();
    }
    public override State RunState()
    {
        if (inRange)
        {
            return killState;
        }
        return this;
    }
    private void Update()
    {
        

        RunState();
        distance = stateManager.distance;

        Debug.Log("Chase: " + distance);

        if (distance < 3 )
        {
            inRange = true;
        }
        else if (distance < 5 && distance > 3)
        {
            transform.LookAt(stateManager.Snake);
            transform.position = Vector3.MoveTowards(transform.position, stateManager.Snake.position, 1 * Time.deltaTime);
            inRange = false;
        }

        
        
    }
        
}
