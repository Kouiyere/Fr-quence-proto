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

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        int destinationID = GetClosestWaypointID(transform.position);
        waypointId = destinationID;
        agent.destination = route.waypointArray[waypointId].position;
    }

    // Update is called once per frame
    void Update()
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

            //Check if out of array
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
