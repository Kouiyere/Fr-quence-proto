using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DroneWheelRotation : MonoBehaviour
{
    public GameObject wheelObject;
    private NavMeshAgent navMeshAgent;
    private HackObject hackDrone;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        hackDrone = GetComponent<HackObject>();
    }
    private void Update()
    {
        if(navMeshAgent.velocity.magnitude > 0 ) 
            wheelObject.transform.Rotate(-3, 0, 0);
        else if (hackDrone.isHacked)
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                wheelObject.transform.Rotate(-3, 0, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                wheelObject.transform.Rotate(3, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                wheelObject.transform.Rotate(-3, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                wheelObject.transform.Rotate(-3, 0, 0);
            }
        }
    }
}
