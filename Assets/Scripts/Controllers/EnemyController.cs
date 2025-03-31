using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 30f;
    Transform target;
    NavMeshAgent agent;
    Animator animator;
    public float movementThreshold = 0.1f;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            // Set destination to player position
            agent.SetDestination(target.position);

            // Check if actually moving (using velocity magnitude)
            bool isMoving = agent.velocity.magnitude > movementThreshold;

            // Only set isWalking if not within stopping distance
            if (distance <= agent.stoppingDistance)
            {
                // When in attack range, stop walking
                animator.SetBool("isWalking", false);
                FaceTarget();

            }
            else
            {
                // Moving towards player but not in attack range
                animator.SetBool("isWalking", isMoving);
            }
        }
        else
        {
            // Outside of detection radius, stop walking
            animator.SetBool("isWalking", false);
        }

        // Debug to check if animation state is changing
        Debug.Log("Is Walking: " + animator.GetBool("isWalking"));
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}