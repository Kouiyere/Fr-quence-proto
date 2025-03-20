using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CalledGuard : MonoBehaviour
{
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void OnCall(GameObject door)
    {
        agent.SetDestination(door.transform.position);
        Debug.Log(agent.remainingDistance);
        if (agent.remainingDistance != 0 && agent.remainingDistance < 0.5f)
        {
            door.GetComponent<HackObject>().Desactivate();
        }
    }
}
