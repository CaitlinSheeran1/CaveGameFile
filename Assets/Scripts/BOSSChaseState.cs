using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BOSSChaseState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    EnemeyCollider colliderController;

    private float attackCooldown = 1f;
    private float attackTimer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        colliderController = animator.GetComponent<EnemeyCollider>();

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

        if (distance > 100)
        {
            animator.SetBool("isChasing", false);
        }

        if (distance < 50)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackCooldown)
            {
                animator.SetBool("isAttacking", true);

                if (colliderController != null)
                {
                    colliderController.EnableColliderWithDelay(0.5f);
                }
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

        if (colliderController != null)
        {
            colliderController.DisableCollider();
        }
    }
}
