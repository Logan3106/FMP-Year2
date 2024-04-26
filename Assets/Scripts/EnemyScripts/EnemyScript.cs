using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private Animator anim;

    public NavMeshAgent agent;

    public float rangeOfPatrol = 20000;

    public Vector3 walkPoint;
    public bool setWalkPoint;

    public float fov;
    public float attackRange;

    public bool isPlayerInFov;
    public bool isPlayerInAttackRange;

    public StateMachine sm;
    public EnemyPatrolState eps;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        sm = gameObject.GetComponent<StateMachine>();

        eps = new EnemyPatrolState(this, sm);

        sm.Init(eps);
    }

    // Update is called once per frame
    void Update()
    {
        if(!(isPlayerInAttackRange && isPlayerInFov))
        {
            sm.ChangeState(eps);
        }
        else if(isPlayerInFov && !isPlayerInAttackRange)
        {
           //Hunting State
        }
        else if (isPlayerInAttackRange)
        {
            //Attack State
        }
        else
        {
            return;
        }
        sm.currentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        sm.currentState.PhysicsUpdate();
    }

    public void Patroling()
    {
        if (!setWalkPoint)
        {
            GenerateWalkPoint();
        }

        if(setWalkPoint)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 disFromTarg = transform.position - walkPoint;
        if(disFromTarg.magnitude > 1f)
        {
            setWalkPoint = false;
        }
    }

    public void GenerateWalkPoint()
    {
        float randomX = Random.Range(-rangeOfPatrol, rangeOfPatrol);
        float randomZ = Random.Range(-rangeOfPatrol, rangeOfPatrol);
        walkPoint = new Vector3(randomX, transform.position.y, randomZ);

        setWalkPoint = true;
    }
}
