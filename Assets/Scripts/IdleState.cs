using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    float timer;
    Transform player;
    public float chaseRange = 8;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var rot = animator.transform.eulerAngles;
        rot.x = 0;
        animator.transform.eulerAngles = rot;

        timer += Time.deltaTime;
        if (timer > 5) animator.SetBool("isPatrolling", true);

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < chaseRange) animator.SetBool("isChasing", true);

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

  
}
