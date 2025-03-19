using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Called : MonoBehaviour
{
    NavMeshAgent agent;
    private JobList jobList;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        jobList = GetComponent<JobList>();
    }

    public void Working()
    {
        agent.SetDestination(jobList.jobs[0].transform.position);
        if (agent.remainingDistance != 0 && agent.remainingDistance < 0.5f)
        {
            jobList.jobs[0].GetComponent<HackObject>().Desactivate();
        }
    }
}
