using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireControl : MonoBehaviour
{
    NavMeshAgent agent;
    [HideInInspector]
    public FireScriptNew fire;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void ExtinguishFire()
    {
        agent.SetDestination(fire.transform.position);
        if (agent.remainingDistance <= 1f)
        {
            //Trigger fire extinguisher animation
            fire.ResetFire();
        }
    }
}
