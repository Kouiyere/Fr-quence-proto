using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CalledInge : MonoBehaviour
{
    NavMeshAgent agent;
    private JobList jobList;
    [HideInInspector]
    public GameObject activeJob;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        jobList = GetComponent<JobList>();
    }

    public void Working()
    {
        agent.SetDestination(activeJob.transform.position);
        if (agent.remainingDistance != 0 && agent.remainingDistance < 0.5f)
        {
            activeJob.GetComponent<HackObject>().Desactivate();
            jobList.jobs.Remove(activeJob);
            activeJob = null;
        }
    }
}
