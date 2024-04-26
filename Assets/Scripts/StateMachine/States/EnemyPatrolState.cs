using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : State
{
    public EnemyPatrolState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
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
        es.Patroling();
    }

    public override void PhysicsUpdate()
    {
        es.GenerateWalkPoint();
    }
}
