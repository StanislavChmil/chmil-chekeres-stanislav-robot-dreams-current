using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    float timer;
    List<Transform> points = new List<Transform>();
    NavMeshAgent agent;
    Transform previousTarget;

    Transform player;
    float chaseRange = 10;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        points.Clear();

        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;

        foreach (Transform t in pointsObject)
        {
            points.Add(t);
        }

        agent = animator.GetComponent<NavMeshAgent>();

        if (points.Count > 0)
        {
            previousTarget = points[0];
            agent.SetDestination(previousTarget.position);
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            Transform nextTarget;

            do
            {
                nextTarget = points[Random.Range(0, points.Count)];
            } while (nextTarget == previousTarget && points.Count > 1);

            previousTarget = nextTarget;
            agent.SetDestination(nextTarget.position);
        }

        timer += Time.deltaTime;
        if (timer > 10f)
        {
            animator.SetBool("isPatrolling", false);
        }
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < chaseRange)
            animator.SetBool("isChasing", true);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent != null)
        {
            agent.SetDestination(agent.transform.position);
        }
    }
}