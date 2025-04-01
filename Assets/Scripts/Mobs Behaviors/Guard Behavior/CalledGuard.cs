using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CalledGuard : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject door;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    

    public void OnCall()
    {
        agent.SetDestination(door.transform.position);
        if (!agent.pathPending && agent.remainingDistance < 0.6f)
        {
            door.GetComponent<HackObject>().Desactivate();
        }
    }
}
