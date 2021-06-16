using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillState : State
{
    
    private void Start()
    {
        
    }
    public override State RunState()
    {
        Debug.Log("Killll!!");
        return this;
    }
}
