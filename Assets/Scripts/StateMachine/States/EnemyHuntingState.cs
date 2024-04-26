using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EnemyHuntingState : State
{
    public EnemyHuntingState(EnemyScript enemyH, StateMachine sm) : base(enemyH, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        Debug.Log("Do hunting logic");
        
        es.Hunting();
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
    }

    /*
    print("enemy state=" + sm.currentState);


    FieldOfView();
        if(!(isPlayerInAttackRange && isPlayerInFov))
        {
            // change to enemy patrol state
            sm.ChangeState(eps);
        }
        else if (isPlayerInFov && !isPlayerInAttackRange)
{
    // change to enemy hunt state
    sm.ChangeState(ehs);
}
else if (isPlayerInAttackRange)
{
    //Attack State
}
else
{
    return;
}
*/


}
