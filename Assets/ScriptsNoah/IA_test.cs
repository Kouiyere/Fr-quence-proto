using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_test : MonoBehaviour
{
    /*
    public Transform pointA;
    public Transform pointB;
    public Transform alertPoint;

    public Material defaultMaterial;
    public Material frozenMaterial;
    public Renderer objRenderer;

    private HackDiversion currentTarget = null;
    public HackFireAlarm alarm;
    private NavMeshAgent agent;

    public float detectionRange = 5f;
    public float stopDistance = 1f;
    private bool movingToB = true;
    private bool isChasing = false;
    private bool isFrozen = false;
    public bool isGuard = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 3f;
        Patrol();
    }

    void Update()
    {
        if (isFrozen) return;

        if (alarm.isHacked)
        {
            if(isGuard)
            {
                ChaseTarget(alarm.transform);
                return;
            }
            else
            {
                ChaseTarget(alertPoint.transform);
                return;
            }
        }

        if (currentTarget == null || !currentTarget.diversion)
        {
            currentTarget = FindClosestActiveTarget();
        }

        if (currentTarget != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, currentTarget.transform.position);

            if (distanceToTarget <= stopDistance)
            {
                //currentTarget.isHacked = false;
                //currentTarget.objRenderer.material = currentTarget.defaultMaterial;
                currentTarget = null;
                isChasing = false;
                movingToB = !movingToB;
                Patrol();
            }
            else
            {
                isChasing = true;
                ChaseTarget(currentTarget.transform);
            }
            return;
        }

        if(alarm.isHacked)
        {
            float distanceToTarget = Vector3.Distance(transform.position, alarm.transform.position);

            if (distanceToTarget <= stopDistance)
            {
                alarm.isHacked = false;
                //alarm.objRenderer.material = currentTarget.defaultMaterial;
                Patrol();
            }
        }

        if (!isChasing && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            movingToB = !movingToB;
            Patrol();
        }
    }

    void Patrol()
    {
        Transform targetPoint = movingToB ? pointB : pointA;
        agent.SetDestination(targetPoint.position);
    }

    void ChaseTarget(Transform target)
    {
        agent.SetDestination(target.position);
    }

    HackDiversion FindClosestActiveTarget()
    {
        HackDiversion[] targets = FindObjectsOfType<HackDiversion>();
        HackDiversion closestTarget = null;
        float closestDistance = detectionRange;

        foreach (HackDiversion target in targets)
        {
            if (target.diversion)
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance <= closestDistance)
                {
                    closestDistance = distance;
                    closestTarget = target;
                }
            }
        }
        return closestTarget;
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            HackElecticity electricalZone = other.GetComponent<HackElecticity>();
            if (electricalZone.isHacked)
            {
                print("enter");
            }
            electricalZone.isHacked = false;
        }
    }
    */
    /*
    public IEnumerator FreezeForSeconds(float seconds)
    {
        isFrozen = true;
        agent.isStopped = true;
        objRenderer.material = frozenMaterial;
        yield return new WaitForSeconds(seconds);
        isFrozen = false;
        agent.isStopped = false;
        objRenderer.material = defaultMaterial;
        Patrol();
    }
    */
}
