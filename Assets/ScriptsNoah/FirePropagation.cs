using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePropagation : MonoBehaviour
{
    public GameObject firePrefab;
    public float propagationRadius = 2f;
    public int maxFlamesInArea = 5;
    public float delayBetweenSpread = 1f;

    public bool directionalPropagation = false;
    public Transform directionTarget;           

    private float spreadTimer;

    private static int globalFlameCount = 0;

    void Start()
    {
        globalFlameCount++;
    }

    void OnDestroy()
    {
        globalFlameCount--;
    }

    void Update()
    {
        if (globalFlameCount >= maxFlamesInArea)
            return;

        spreadTimer += Time.deltaTime;
        if (spreadTimer >= delayBetweenSpread)
        {
            spreadTimer = 0f;
            TrySpreadFire();
        }
    }

    void TrySpreadFire()
    {
        if (globalFlameCount >= maxFlamesInArea)
            return;

        Vector3 spawnDirection;
        if (directionalPropagation && directionTarget != null)
        {
            spawnDirection = (directionTarget.position - transform.position).normalized;
        }
        else
        {
            spawnDirection = Random.insideUnitSphere;
            spawnDirection.y = 0f;
            spawnDirection.Normalize();
        }

        Vector3 spawnOffset = spawnDirection * Random.Range(1f, propagationRadius);
        Vector3 rayOrigin = transform.position + spawnOffset + Vector3.up * 5f;

        if (Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, 10f))
        {
            if (hit.collider.CompareTag("Floor"))
            {
                Instantiate(firePrefab, hit.point, Quaternion.identity);
                globalFlameCount++;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, propagationRadius);
    }
}
