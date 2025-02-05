using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_test : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public Material defaultMaterial;
    public Material frozenMaterial;
    public Renderer objRenderer;

    private HackDiversion currentTarget = null;

    public float speed = 3f;
    public float detectionRange = 5f;
    public float stopDistance = 1f;
    private bool movingToB = true;
    private bool isChasing = false;
    private bool isFrozen = false;

    void Update()
    {
        if (isFrozen) return;

        if (currentTarget == null || !currentTarget.diversion)
        {
            currentTarget = FindClosestActiveTarget();
        }

        if (currentTarget != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, currentTarget.transform.position);

            if (distanceToTarget <= stopDistance)
            {
                currentTarget.isActivated = false;
                currentTarget.objRenderer.material = currentTarget.defaultMaterial;
                currentTarget = null;
                isChasing = false;
                movingToB = !movingToB; 
            }
            else
            {
                isChasing = true;
                ChaseTarget(currentTarget.transform);
            }
            return;
        }

        isChasing = false;
        Patrol();
    }

    void Patrol()
    {
        Transform targetPoint = movingToB ? pointB : pointA;
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            movingToB = !movingToB;
        }
    }

    void ChaseTarget(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            HackElecticity electricalZone = other.GetComponent<HackElecticity>();
            if(electricalZone.isActivated)
            {
                StartCoroutine(FreezeForSeconds(3f));
            }
        }
    }

    public IEnumerator FreezeForSeconds(float seconds)
    {
        isFrozen = true;
        yield return new WaitForSeconds(seconds);
        isFrozen = false;
    }

    public void FrozenState()
    {
        if(isFrozen)
        {
            objRenderer.material = frozenMaterial;
        }
        else
        {
            objRenderer.material = defaultMaterial;
        }
    }
}


