using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBehaviorComponent : MonoBehaviour {

    private Rigidbody RB;
    private NavMeshAgent agent;
    public GameObject Target;

    public float AttackRange;
    public float AttackDelay;
    private float SetAttackDelay;
    public GameObject HitBox;

    float DT;
	// Use this for initialization
	void Start () {

        RB = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Target.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        DT = Time.deltaTime;
        SetAttackDelay -= DT;

        if (agent.remainingDistance <= AttackRange) // Check to see if we are 
        {                                               //in range to target
            agent.isStopped = true; // Force the agent to stop

            if (SetAttackDelay <= 0) // Check to see if we can attack
            {
                Debug.Log("Attack"); // do attack
                SetAttackDelay = AttackDelay; // reset setattackdelay to pre defined value (Magic Number)

            }
        }
        else
        {
            agent.isStopped = false; // Allow agent to move
            agent.SetDestination(Target.transform.position); // Move to a location
        }
	}
}
