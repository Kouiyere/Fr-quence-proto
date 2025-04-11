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
    public GameObject sparklesParticle;
    public GameObject fireParticle;

    public GameObject trashPrefab;
    public bool trash = false;
    public bool fire = false;
    private bool broken = false;

    private void Start()
    {
        hackObject = GetComponent<HackObject>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = movementSpeed;
        InvokeRepeating(nameof(SpawnTrash),0.5f,0.5f);
        BrokenDrone();
        FireDrone(fire);
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

        if(broken)
        {
            agent.SetDestination(spawnPoint.transform.position);
        }

        else if (currentTarget != null)
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
        if (broken == false)
        {
            HackWaste waste = other.GetComponent<HackWaste>();

            if (waste != null && waste.AttractRobot)
            {
                waste.AttractRobot = false;
                currentTarget = null;
                Destroy(waste);
            }

            if (other.gameObject.CompareTag("Trash"))
            {
                trash = true;
                Invoke(nameof(ResetTrash), 10f);
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        FireScriptNew fireScript = other.gameObject.GetComponent<FireScriptNew>();
        HackWaste waste = other.gameObject.GetComponent<HackWaste>();

        if (waste != null && fireScript != null && waste.AttractRobot)
        {
            waste.AttractRobot = false;
            currentTarget = null;
            if(fire == false)
            {
                Destroy(waste.transform.gameObject);
            }
            else
            {
                fireScript.isOnFire = true;
            }

            if (fireScript.isOnFire == true)
            {
                fire = true;
                FireDrone(fire);
                //Invoke(nameof(ResestFire), 15f);

            }
        }

        if (other.gameObject.CompareTag("Trash"))
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
    private void ResetTrash()
    {
        trash = false;
    }

    private void BrokenDrone()
    {
        if(broken == true)
        {
            sparklesParticle.SetActive(true);
        }
        else
        {
            sparklesParticle.SetActive(false);
        }
    }

    private void FireDrone(bool pFire)
    {
        if(pFire == true)
        {
            broken = true;
            BrokenDrone();
            fireParticle.SetActive(true);

        }
        else
        {
            fireParticle.SetActive(false);
        }
    }

    private void ResestFire()
    {
        fire = false;
        FireDrone(fire);
    }
}
