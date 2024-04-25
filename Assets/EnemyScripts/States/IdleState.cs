using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : Statemachine
{
    public ChaseState chaseState;
    public bool canSeeThePlayer;

    public override Statemachine RunCurrentState()
    {
        if (canSeeThePlayer)
        {
            return chaseState;
        }
        else
        {
            return this;
        }  
    }
}
