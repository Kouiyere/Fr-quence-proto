using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackDetection : MonoBehaviour
{
    public float fov = 45f;
    public float distance = 5f;
    private Color color = Color.white;
    private Collider[] hacks;

    void Update()
    {
        CanSeeHack();
        DebugFov(fov, distance, color);
    }

    public GameObject CanSeeHack()
    {
        int mask = LayerMask.GetMask("Hackable");
        hacks = Physics.OverlapSphere(transform.position, distance, mask);

        if (hacks.Length > 0)
        {
            foreach (var hack in hacks)
            {
                GameObject hackGO = hack.gameObject;
                HackDiversion diversionScript = hack.GetComponent<HackDiversion>();
                if (diversionScript != null && diversionScript.diversion)
                {
                    Vector3 toHack = new Vector3((hack.transform.position.x - transform.position.x), (hack.transform.position.y - transform.position.y), (hack.transform.position.z - transform.position.z));
                    float angle = Vector3.Angle(toHack, transform.forward);
                    if (angle <= fov)
                    {
                        RaycastHit hit;
                        if (Physics.Raycast(transform.position, hack.transform.position, out hit, Mathf.Infinity))
                        {
                            color = Color.red;
                            return hit.collider.gameObject;
                        }
                        else
                        {
                            color = Color.yellow;
                            return null;
                        }
                    }
                    else
                    {
                        color = Color.yellow;
                        return null;
                    }
                }
                else
                {
                    color = Color.white;
                    return null;
                }
            }
        }
        else
        {
            color = Color.white;
            return null;
        }
    }

    private void DebugFov(float angle, float distance, Color color)
    {
        Vector3 extentLeft = Quaternion.AngleAxis(angle, Vector3.up) * transform.forward;
        Vector3 extentRight = Vector3.Reflect(extentLeft, transform.right);
        Debug.DrawRay(transform.position, extentLeft * distance, color);
        Debug.DrawRay(transform.position, extentRight * distance, color);
        GameObject hack = CanSeeHack();
        if (hack != null)
        {
            Vector3 toHack = new Vector3((hack.transform.position.x - transform.position.x), (hack.transform.position.y - transform.position.y), (hack.transform.position.z - transform.position.z));
            Debug.DrawRay(transform.position, toHack, color);
        }
    }
}
