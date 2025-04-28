using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;

    private float attackCooldown = 1f; 
    private float attackTimer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = 35.0f;

        attackTimer = 0f; 
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var rot = animator.transform.eulerAngles;
        rot.x = 0;
        animator.transform.eulerAngles = rot;

        agent.SetDestination(player.position);

        float distance = Vector3.Distance(player.position, animator.transform.position);

        if (distance > 40)
        {
            animator.SetBool("isChasing", false);
        }
        
        if (distance < 20)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackCooldown)
            {
                animator.SetBool("isAttacking", true);
            }
        }
        else
        {
            attackTimer = 0f; 
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);
    }
}
