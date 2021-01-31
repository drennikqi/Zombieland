using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    EnemyHealth health;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update(){
        if (health.IsDead()) {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= chaseRange) {
            isProvoked = true;
        }
        if (isProvoked) {
            EngageTarget();
        }
    }

    public void OnDamageTaken() {
        isProvoked = true;
    }

    void EngageTarget() {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance) {
            ChaseTarget();
        } 
        if(distanceToTarget <= navMeshAgent.stoppingDistance) {
            AttackTarget();
        }
    }

    private void ChaseTarget() {
        GetComponent<Animator>().SetTrigger("move");
        GetComponent<Animator>().SetBool("attack", false);
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget() {
        GetComponent<Animator>().SetBool("attack" , true);
        Debug.Log(name + " is attacking " + target.name);
    }

    private void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
