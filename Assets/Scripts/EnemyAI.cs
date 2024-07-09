using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f; //range the player can come closer to the enemy
    [SerializeField] float turnSpeed = 5f;
    NavMeshAgent navMeshAgent; //used for creating path finding AI
    float distanceToTarget = Mathf.Infinity; //infinite distance
    bool isProvoked = false;
    EnemyHealth health;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); //just getting the navmesh agent and getting it once at start only (aka wtf is navmesh variable that we just created)
    //instantiating
        health = GetComponent<EnemyHealth>();
    }
    

    void Update()
    {
        if(health.IsDead()) //enemy doesnt act up after death
        {
            enabled = false; //doesnt do crazy animations again and again if shoot after death
            navMeshAgent.enabled = false; //stopps following
            return;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position); //distance from the enemy to player
        if(isProvoked) //when provoked
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange) //also provoke when
        {
            isProvoked = true;
        }    
    }
    public void OnDamageTaken() // for making the enemy follow u when provoked
    {
        isProvoked = true;
    }
    private void EngageTarget()
    {
        FaceTarget();
        if(distanceToTarget >= navMeshAgent.stoppingDistance) //chase target until the stopping distance is reached 
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance) //attack when the enemy's distance is less or equal to the stopping distance
        {
            AttackTarget();
        }
    }

    private void AttackTarget() //making separate methods so for it to be more clear if additional features need to be added in the future
    {
        GetComponent<Animator>().SetBool("Attack",true); //not a trigger this time but a bool
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack",false); //doesnt attaack the player when chasing
        GetComponent<Animator>().SetTrigger("Move"); //trigger this particular thing
        navMeshAgent.SetDestination(target.position); //moving the enemy to player
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized; //pos of target - pos of enemy 
        //normalized cuz we are intrested in just direction and not mangnitude and all the other stuff
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0 ,direction.z));
        //quaternion is related to rotation and here we are doing a "look rotation"
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed); //current rot, look, time indep
        //slerp = spherical interpollation which allows smooth rotation between 2 vectors
    }

    void OnDrawGizmosSelected() //when the game object is selected
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
