using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected EnemyScript es;

    protected StateMachine sm;

    //Constructor for the base
    protected State(EnemyScript es, StateMachine sm)
    {
        this.es = es;
        this.sm = sm;
    }

    #region Common Methods
    public virtual void Enter()
    {
        //Debug.Log("This is base.enter");
    }

    public virtual void HandleInput()
    {
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }

    public virtual void Exit()
    {
    }
    #endregion

}
