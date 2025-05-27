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
    private List<Vector3> laserPos = new List<Vector3>();

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        hackObject = GetComponent<HackObject>();
        lineRenderer.enabled = false;
    }

    void Update()
    {
        laserPos.Clear();
        if (hackObject.isHacked)
        {
            FireLaser(laserOrigin.position, laserOrigin.forward);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    void FireLaser(Vector3 origine, Vector3 direction)
    {
        lineRenderer.enabled = true;
        laserPos.Add(origine);

        Ray ray = new Ray(origine, direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, laserRange, hitLayers))
        {
            CheckHitObject(hit, direction);
        }
        else
        {
            laserPos.Add(ray.GetPoint(laserRange));
            UpdateLaser();
        }
    }

    void UpdateLaser()
    {
        int count = 0;
        lineRenderer.positionCount = laserPos.Count;

        foreach (Vector3 pos in laserPos)
        {
            lineRenderer.SetPosition(count, pos);
            count++;
        }
    }

    void CheckHitObject(RaycastHit hit, Vector3 direction)
    {
        if (hit.collider.gameObject.GetComponent<FireScriptNew>())
        {
            hit.collider.gameObject.GetComponent<FireScriptNew>().SetOnFire();
        }

        if(hit.collider.CompareTag("Enemy"))
        {
            hit.collider.gameObject.GetComponent<HealthAI>().TakeDamage(100);
        }

        if (hit.collider.CompareTag("Mirror"))
        {
            FireLaser(hit.point, Vector3.Reflect(direction, hit.normal));
        }
        else
        {
            laserPos.Add(hit.point);
            UpdateLaser();
        }
    }
}

