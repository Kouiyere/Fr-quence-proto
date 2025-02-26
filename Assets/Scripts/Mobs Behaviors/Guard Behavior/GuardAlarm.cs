using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAlarm : MonoBehaviour
{
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void TurnOfAlarm(Transform alarmPos)
    {
        agent.destination = alarmPos.position;
    }
}
