using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Working : MonoBehaviour
{
    NavMeshAgent agent;
    public PatrolRoute route;
    private int waypointID;

    public float workTime = 5f;
    private float timer;
    private float walkingSpeed;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        waypointID = GetClosestWaypointID(transform.position);
        agent.SetDestination(route.waypointArray[waypointID].position);
        walkingSpeed = GetComponent<WorkerStateMachine>().walkingSpeed;
    }

    public void Work()
    {
        //Check if destination is on the patrol route
        if (agent.destination != route.waypointArray[waypointID].position)
        {
            agent.SetDestination(route.waypointArray[waypointID].position);
        }

        if (agent.remainingDistance < 0.5f)
        {
            waypointID++;
            if (waypointID >= route.waypointArray.Length)
            {
                waypointID = 0;
            }
            agent.SetDestination(route.waypointArray[waypointID].position);

            timer = workTime;
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            agent.speed = 0;
        }
        else if (timer <= 0)
        {
            agent.speed = walkingSpeed;
        }
    }

    private int GetClosestWaypointID(Vector3 position)
    {
        float closestDistance = Mathf.Infinity;
        int closestWaypointID = 0;
        for (int i = 0; i < route.waypointArray.Length; i++)
        {
            float dist = Vector3.Distance(position, route.waypointArray[i].position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestWaypointID = i;
            }
        }
        return closestWaypointID;
    }
}
