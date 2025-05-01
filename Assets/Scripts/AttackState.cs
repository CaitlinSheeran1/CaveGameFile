using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    EnemeyCollider colliderController; 


    Transform player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        colliderController = animator.GetComponent<EnemeyCollider>(); 

    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var rot = animator.transform.eulerAngles;
        rot.x = 0;
        animator.transform.eulerAngles = rot;

        animator.transform.LookAt(player);
        float distance = Vector3.Distance(player.position, animator.transform.position);

        if (distance > 20) animator.SetBool("isAttacking", false);


        
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (colliderController != null)   
        {
            colliderController.DisableCollider();
        }
    }


}
