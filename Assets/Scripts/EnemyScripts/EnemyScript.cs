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

    public AudioSource source;

    public NavMeshAgent agent;

    public float rangeOfPatrol = 20000;

    public Vector3 walkPoint;
    public bool setWalkPoint;

    public float fov;
    public float attackRange;
    [Range(0, 360)]
    public float angle;
    public float sight;

    public GameObject playerRef;
    public Transform enemiesEyes;
    [SerializeField] GameObject ultimateTarget;

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
        isPlayerInFov = Physics.CheckSphere(transform.position, fov, targetMask);
        isPlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, targetMask);
        SoundEffects();

        //Broken code

        /*
        FieldOfView(45);
        FieldOfView(30);
        FieldOfView(15);
        FieldOfView(0);
        FieldOfView(-15);
        FieldOfView(-30);
        FieldOfView(-45);
        */
        //DO NOT PUT ANY STATE LOGIC IN HERE

        sm.currentState.HandleInput();
        sm.currentState.LogicUpdate();

        Debug.Log("last state= " + sm.lastState + "  current state=" + sm.currentState );


    }

    void FixedUpdate()
    {
        sm.currentState.PhysicsUpdate();
    }


    public void SoundEffects()
    {
        if(isPlayerInFov == true)
        {
            if (source.isPlaying) return;

            source.Play();
            print("Play Music");
        }
        else
        {
            source.Stop();
            print("Stop Music");
        }
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
            //print("Changing1");
        }
    }

    public void Hunting()
    {
        print("hunting");
        agent.SetDestination(playerRef.transform.position);

        //Change to patrol state
        if (!isPlayerInFov && !isPlayerInAttackRange)
        {
            sm.ChangeState(eps);
            //print("Changing2");
        }
    }
    

    public void GenerateWalkPoint()
    {
        float randomX = Random.Range(-rangeOfPatrol, rangeOfPatrol);
        float randomZ = Random.Range(-rangeOfPatrol, rangeOfPatrol);
        walkPoint = new Vector3(randomX, transform.position.y, randomZ);

        setWalkPoint = true;
    }

    //Borken Code

    /*public void FieldOfView(float angleIn)
    {
        Vector3 start = enemiesEyes.position;
        Quaternion angle = Quaternion.Euler(0, angleIn, 0);

        Physics.Raycast(start, angle * transform.forward, out RaycastHit hit, sight);

        if (hit.transform == null) return;

        Debug.DrawLine(start, hit.transform.position, Color.red);

        if(hit.collider.tag == "Player")
        {
            ultimateTarget = hit.transform.gameObject;
            print("Player Seen");
        }
    {

    private IEnumerator FOVRutine()
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
