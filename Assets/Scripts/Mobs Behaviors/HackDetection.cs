using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackDetection : MonoBehaviour
{
    public float fov = 45f;
    public float distance = 5f;
    private Color color = Color.white;

    void Update()
    {
        DebugFov(fov, distance, color);
    }

    private void OnTriggerStay(Collider other)
    {
        HackObject hackScript = other.GetComponent<HackObject>();
        if (hackScript != null && hackScript.isHacked)
        {
            CanSeeHack(other.gameObject);
        }
    }

    public bool CanSeeHack(GameObject hack)
    {
        Vector3 toHack = new Vector3((hack.transform.position.x - transform.position.x), (hack.transform.position.y - transform.position.y), (hack.transform.position.z - transform.position.z));
        float angle = Vector3.Angle(toHack, transform.forward);
        if (angle <= fov)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, hack.transform.position, out hit, Mathf.Infinity))
            {
                color = Color.red;
                return true;
            }
            else
            {
                color = Color.yellow;
                return false;
            }
        }
        else
        {
            color = Color.yellow;
            return false;
        }
    }

    private void DebugFov(float angle, float distance, Color color)
    {
        Vector3 extentLeft = Quaternion.AngleAxis(angle, Vector3.up) * transform.forward;
        Vector3 extentRight = Vector3.Reflect(extentLeft, transform.right);
        Debug.DrawRay(transform.position, extentLeft * distance, color);
        Debug.DrawRay(transform.position, extentRight * distance, color);
    }
}
