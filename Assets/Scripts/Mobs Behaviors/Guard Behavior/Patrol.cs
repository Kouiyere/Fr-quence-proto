using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

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

    private int waypointID;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        waypointID = GetClosestWaypointID(transform.position);
        agent.SetDestination(route.waypointArray[waypointID].position);
    }

    public void Patroling()
    {
        //Check if destination is on the patrol route
        if (agent.destination != route.waypointArray[waypointID].position)
        {
            agent.SetDestination(route.waypointArray[waypointID].position);
        }

        if (agent.remainingDistance < .05f)
        {
            if (routeType == RouteType.BackAndForth && reverse)
            {
                waypointID--;
            }
            else
            {
                waypointID++;
            }

            //Check when out of array
            if (routeType == RouteType.Loop)
            {
                if (waypointID > route.waypointArray.Length - 1)
                {
                    waypointID = 0;
                }
            }
            else if (routeType == RouteType.BackAndForth)
            {
                if (!reverse && waypointID > route.waypointArray.Length - 1)
                {
                    reverse = true;
                    waypointID -= 2;
                }
                else if (reverse && waypointID < 0)
                {
                    reverse = false;
                    waypointID = 1;
                }
            }

            agent.SetDestination(route.waypointArray[waypointID].position);
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
