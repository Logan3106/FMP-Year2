using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class EnemyScript : MonoBehaviour
{
    private Animator anim;

    public NavMeshAgent agent;

    public float rangeOfPatrol = 20000;

    public Vector3 walkPoint;
    public bool setWalkPoint;

    public float fov;
    public float attackRange;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructuionMask;

    public bool isPlayerInFov;
    public bool isPlayerInAttackRange;

    public StateMachine sm;
    public EnemyPatrolState eps;
    public EnemyHuntingState ehs;

    

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        sm = gameObject.GetComponent<StateMachine>();

        //set up states
        eps = new EnemyPatrolState(this, sm);
        sm.Init(eps);

        ehs = new EnemyHuntingState(this, sm);
        sm.Init(ehs);



        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        //DO NOT PUT ANY STATE LOGIC IN HERE

        sm.currentState.HandleInput();
        sm.currentState.LogicUpdate();

        Debug.Log("last state= " + sm.lastState + "  current state=" + sm.currentState );


    }

    void FixedUpdate()
    {
        sm.currentState.PhysicsUpdate();
    }

    //patroling state check
    public void Patroling()
    {
        if (!setWalkPoint)
        {
            GenerateWalkPoint();
        }

        if (setWalkPoint)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 disFromTarg = transform.position - walkPoint;
        if (disFromTarg.magnitude > 1f)
        {
            setWalkPoint = false;
        }

        if (isPlayerInFov && !isPlayerInAttackRange)
        {
            // change to enemy hunt state
           sm.ChangeState(ehs);
        }
    }

    public void Hunting()
    {
        print("hunting");
        agent.SetDestination(playerRef.transform.position);

        if (!(isPlayerInFov && isPlayerInAttackRange))
        {
            sm.ChangeState(eps);
        }
    }
    

    public void GenerateWalkPoint()
    {
        float randomX = Random.Range(-rangeOfPatrol, rangeOfPatrol);
        float randomZ = Random.Range(-rangeOfPatrol, rangeOfPatrol);
        walkPoint = new Vector3(randomX, transform.position.y, randomZ);

        setWalkPoint = true;
    }

    public void FieldOfView()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, fov, targetMask);

        if(rangeChecks.Length != 0)
        {

            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget2 = Vector3.Distance(transform.position, target.position);
                
                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget2))
                {
                    isPlayerInFov = true;
                }
                else
                {
                    isPlayerInFov = false;
                }
            }
        }
        
    }

   /* private IEnumerator FOVRutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return null;
            FieldOfView();
        }
    }
   */
}
