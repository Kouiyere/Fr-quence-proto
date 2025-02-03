using System.Collections;
using UnityEngine;

public class CurvePoint : MonoBehaviour
{
    [HideInInspector] public bool showGizmo = true;
    [HideInInspector] public float gizmoSize = 0.1f;
    [HideInInspector] public Color gizmoColor = new Color(1, 0, 0, 0.5f);

    private void OnDrawGizmos()
    {
        if (showGizmo == true)
        {
            Gizmos.color = gizmoColor;

            Gizmos.DrawSphere(transform.position, gizmoSize);
        }
    }

    //update parent curve when this point moved
    private void OnDrawGizmosSelected()
    {
        CurveRenderer curvedLine = transform.parent.GetComponent<CurveRenderer>();

        if (curvedLine != null)
        {
            curvedLine.Update();
        }
    }
}
