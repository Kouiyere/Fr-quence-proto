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

    public float speed = 1000f;
    public float rotationLimit = 45f;
    private float currentYRotation = 0f;
    private float initialYRotation;

    void Start()
    {
        initialYRotation = transform.eulerAngles.y;
        lineRenderer = GetComponent<LineRenderer>();
        hackObject = GetComponent<HackObject>();
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (hackObject.isHacked)
        {
            FireLaser();
            MoveLaser();
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

    void MoveLaser()
    {
        float rotationAmount = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentYRotation += rotationAmount;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentYRotation -= rotationAmount;
        }

        currentYRotation = Mathf.Clamp(currentYRotation, -rotationLimit, rotationLimit);

        transform.rotation = Quaternion.Euler(0, initialYRotation + currentYRotation, 0);
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

