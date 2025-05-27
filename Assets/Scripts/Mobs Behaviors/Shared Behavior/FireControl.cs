using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireControl : MonoBehaviour
{
    NavMeshAgent agent;
    //[HideInInspector]
    public GameObject fire;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void ExtinguishFire()
    {
        agent.SetDestination(fire.transform.position);
        if (agent.remainingDistance <= 3f)
        {
            //Trigger fire extinguisher animation
            if (fire.GetComponent<FireGrowth>())
            {
                Destroy(fire);
            }
            if (fire.GetComponent<FirePropagation>())
            {
                fire.GetComponentInParent<FireScriptNew>().ResetFire();
            }
        }
    }
}
