using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public Transform Snake;
    public State currentState;
    public float distance { get; set; }
    private void Start()
    {
        currentState = GetComponent<IdleState>();
    }
    private void Update()
    {
        distance = Vector3.Distance(this.gameObject.transform.position, Snake.transform.position);


        RunStatemachine();
    }

    private int BetweenIdleandMove()
    {
        return Random.Range(5, 15);
    }



    private void RunStatemachine()
    {
        State nextState = currentState?.RunState();

        if (nextState != null)
        {
            SwitchtoNextStage(nextState);
        }
    }
    private void SwitchtoNextStage(State nextState)
    {
        currentState = nextState;
    }
}
