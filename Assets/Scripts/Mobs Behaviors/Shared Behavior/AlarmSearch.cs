using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlarmSearch : MonoBehaviour
{
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SearchFire()
    {
        if (agent.remainingDistance < 0.05f)
        {
            Vector3 dest = transform.position + Random.insideUnitSphere * 10;
            agent.SetDestination(dest);           
        }
    }
}
