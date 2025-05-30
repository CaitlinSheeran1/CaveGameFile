using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BOSSPatrollState : StateMachineBehaviour
{
    float timer;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;
    Transform player;
    public float chaseRange = 8;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 10.0f;
        timer = 0;
        GameObject go = GameObject.FindGameObjectWithTag("WayPoints");
        foreach (Transform t in go.transform)
        {
            wayPoints.Add(t);
        }

        agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var rot = animator.transform.eulerAngles;
        rot.x = 0;
        animator.transform.eulerAngles = rot;

        //if (agent.remainingDistance <= agent.stoppingDistance)
        //    agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);

        //timer += Time.deltaTime;
        //if (timer > 10) animator.SetBool("isPatrolling", false);

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < chaseRange) animator.SetBool("isChasing", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
