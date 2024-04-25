using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : Statemachine
{
    public override Statemachine RunCurrentState()
    {
        Debug.Log("I have attacked");
        return this;
    }
}
