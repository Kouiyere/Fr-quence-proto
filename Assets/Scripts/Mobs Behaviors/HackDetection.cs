using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackDetection : MonoBehaviour
{
    public float fov = 45f;
    public float distance = 5f;
    private Color color;

    void Update()
    {
        DebugFov(fov, distance, color);
    }

    private void DebugFov(float angle, float distance, Color color)
    {
        Vector3 extentLeft = Quaternion.AngleAxis(angle, Vector3.up) * transform.forward;
        Vector3 extentRight = Vector3.Reflect(extentLeft, transform.right);
        Debug.DrawRay(transform.position, extentLeft * distance, color);
        Debug.DrawRay(transform.position, extentRight * distance, color);
    }
}
