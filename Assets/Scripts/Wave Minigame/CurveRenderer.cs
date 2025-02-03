using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveRenderer : MonoBehaviour
{
    public float curveSegmentSize = 0.15f;
    public float curveWidth = 0.1f;
    [Header("Gizmos")]
    public bool showGizmos = true;
    public float gizmoSize = 0.1f;
    public Color gizmoColor = new Color(1, 0, 0, 0.5f);

    private CurvePoint[] curvePoints = new CurvePoint[0];
    private Vector3[] curvePositions = new Vector3[0];
    private Vector3[] curvePositionsOld = new Vector3[0];


    // Update is called once per frame
    public void Update()
    {
        GetPoints();
        SetPointsToCurve();
    }

    void GetPoints()
    {
        //find points in children
        curvePoints = this.GetComponentsInChildren<CurvePoint>();

        //add positions
        curvePositions = new Vector3[curvePoints.Length];
        for (int i = 0; i < curvePoints.Length; i++)
        {
            curvePositions[i] = curvePoints[i].transform.position;
        }
    }

    void SetPointsToCurve()
    {
        //create old positions if mismatch
        if (curvePositionsOld.Length != curvePositions.Length)
        {
            curvePositionsOld = new Vector3[curvePositions.Length];
        }

        //check if points have moved
        bool moved = false;
        for (int i = 0;i < curvePositions.Length;i++)
        {
            //compare
            if (curvePositions[i] != curvePositionsOld[i])
            {
                moved = true;
            }
        }

        //update if moved
        if (moved)
        {
            LineRenderer curve = GetComponent<LineRenderer>();

            //get smoothed values
            Vector3[] smoothedPoints = LineSmoother.SmoothLine(curvePositions, curveSegmentSize);

            //set curve settings
            curve.positionCount = smoothedPoints.Length;
            curve.SetPositions(smoothedPoints);
            curve.startWidth = curveWidth;
            curve.endWidth = curveWidth;
        }
    }

    void OnDrawGizmosSelected()
    {
        Update();
    }

    void OnDrawGizmos()
    {
        if (curvePoints.Length == 0)
        {
            GetPoints();
        }

        //settings for gizmos
        foreach(CurvePoint curvePoint in curvePoints)
        {
            curvePoint.showGizmo = showGizmos;
            curvePoint.gizmoSize = gizmoSize;
            curvePoint.gizmoColor = gizmoColor;
        }
    }
}
