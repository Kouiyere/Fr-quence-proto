using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cleaning : MonoBehaviour
{
    NavMeshAgent agent;
    [HideInInspector]
    public GameObject trash;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void CleanTrash()
    {
        agent.SetDestination(trash.transform.position);
        if (agent.remainingDistance <= .2f && !agent.pathPending)
        {
            //cleaning animation
            Destroy(trash);
        }
    }
}
