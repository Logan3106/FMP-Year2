using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : Statemachine
{
    public AttackState attackState;
    public bool isInAttackRange;

    public override Statemachine RunCurrentState()
    {
        if (isInAttackRange)
        {
            return new AttackState();
        }
         return this; 
    }
}
