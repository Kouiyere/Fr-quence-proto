using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    NavMeshAgent agent;
    public PatrolRoute route;
    public enum RouteType
    {
        Loop,
        BackAndForth
    }
    public RouteType routeType;
    private bool reverse = false;

    private int waypointId;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        int destinationID = GetClosestWaypointID(transform.position);
        waypointId = destinationID;
        agent.destination = route.waypointArray[waypointId].position;
    }

    public void Patroling()
    {
        if (agent.remainingDistance < .01f)
        {
            if (routeType == RouteType.BackAndForth && reverse)
            {
                waypointId--;
            }
            else
            {
                waypointId++;
            }

            //Check when out of array
            if (routeType == RouteType.Loop)
            {
                if (waypointId > route.waypointArray.Length - 1)
                {
                    waypointId = 0;
                }
            }
            else if (routeType == RouteType.BackAndForth)
            {
                if (!reverse && waypointId > route.waypointArray.Length - 1)
                {
                    reverse = true;
                    waypointId -= 2;
                }
                else if (reverse && waypointId < 0)
                {
                    reverse = false;
                    waypointId = 1;
                }
            }

            agent.destination = route.waypointArray[waypointId].position;
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
