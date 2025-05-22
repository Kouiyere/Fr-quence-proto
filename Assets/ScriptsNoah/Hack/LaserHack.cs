using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHack : MonoBehaviour
{
    public Transform laserOrigin;
    public float laserRange = 50f;
    public LayerMask hitLayers;
    private LineRenderer lineRenderer;
    private HackObject hackObject;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        hackObject = GetComponent<HackObject>();
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (hackObject.isHacked)
        {
            FireLaser();
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    void FireLaser()
    {
        lineRenderer.enabled = true;
        RaycastHit hit;
        Vector3 laserEnd = laserOrigin.position + laserOrigin.forward * laserRange;

        if (Physics.Raycast(laserOrigin.position, laserOrigin.forward, out hit, laserRange, hitLayers))
        {
            laserEnd = hit.point;
            CheckHitObject(hit.collider);
        }

        lineRenderer.SetPosition(0, laserOrigin.position);
        lineRenderer.SetPosition(1, laserEnd);
    }

    void CheckHitObject(Collider hitCollider)
    {
        if (hitCollider.CompareTag("FireObject"))
        {
            hitCollider.gameObject.GetComponent<FireScriptNew>().SetOnFire();
        }

        if(hitCollider.CompareTag("Enemy"))
        {
            hitCollider.gameObject.GetComponent<HealthAI>().TakeDamage(100);
        }
    }
}

