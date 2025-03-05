using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HackDrone : HackObject
{
    public float movementSpeed = 1f;
    private NavMeshAgent agent;
    private HackWaste currentTarget;

    public GameObject trashPrefab;
    public bool trash = false;

    protected new void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = movementSpeed;
        InvokeRepeating(nameof(SpawnTrash),0.5f,0.5f);
    }

    public void Update()
    {
        if (isHacked)
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

        if (currentTarget != null && !currentTarget.isHacked)
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
    }

    private HackWaste FindClosestActiveWaste()
    {
        HackWaste[] wastes = FindObjectsOfType<HackWaste>();
        HackWaste closestWaste = null;
        float closestDistance = Mathf.Infinity;

        foreach (HackWaste waste in wastes)
        {
            if (waste.isHacked)
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

        if (waste != null && waste.isHacked)
        {
            waste.isHacked = false;
            currentTarget = null;
            waste.GetComponent<MeshRenderer>().material = waste.defaultMaterial;
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
