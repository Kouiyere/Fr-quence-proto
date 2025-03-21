using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HackDrone : MonoBehaviour
{
    private HackObject hackObject;
    public float movementSpeed = 1f;
    private NavMeshAgent agent;
    private HackWaste currentTarget;
    public GameObject spawnPoint;

    public GameObject trashPrefab;
    public bool trash = false;

    private void Start()
    {
        hackObject = GetComponent<HackObject>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = movementSpeed;
        InvokeRepeating(nameof(SpawnTrash),0.5f,0.5f);
    }

    public void Update()
    {
        if (hackObject.isHacked)
        {
            ManualControl();
        }
        else
        {
            MoveToClosestActiveWaste();
        }
    }

    private void ManualControl()
    {
        agent.isStopped = true;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 1, 0);
        }
    }

    private void MoveToClosestActiveWaste()
    {
        agent.isStopped = false;

        if (currentTarget != null && !currentTarget.AttractRobot)
        {
            currentTarget = null;
        }

        if (currentTarget == null)
        {
            currentTarget = FindClosestActiveWaste();
        }

        if (currentTarget != null)
        {
            agent.SetDestination(currentTarget.transform.position);
        }
        else
        {
            agent.SetDestination(spawnPoint.transform.position);
        }
    }

    private HackWaste FindClosestActiveWaste()
    {
        HackWaste[] wastes = FindObjectsOfType<HackWaste>();
        HackWaste closestWaste = null;
        float closestDistance = Mathf.Infinity;

        foreach (HackWaste waste in wastes)
        {
            if (waste.AttractRobot)
            {
                float distance = Vector3.Distance(transform.position, waste.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestWaste = waste;
                }
            }
        }
        return closestWaste;
    }

    private void OnTriggerEnter(Collider other)
    {
        HackWaste waste = other.GetComponent<HackWaste>();

        if (waste != null && waste.AttractRobot)
        {
            waste.AttractRobot = false;
            currentTarget = null;
            waste.GetComponent<MeshRenderer>().material = waste.defaultMat;
        }

        if(other.gameObject.CompareTag("Trash"))
        {
            trash = true;
        }
    }

    private void SpawnTrash()
    {
        if (trash)
        {
            Instantiate(trashPrefab, new Vector3(transform.position.x, transform.position.y-0.25f, transform.position.z), transform.rotation);
        }
    }
}
