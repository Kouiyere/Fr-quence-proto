using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveRenderer : MonoBehaviour
{
    private CurvePoint[] curvePoints = new CurvePoint[0];
    private Vector3[] curvePositions = new Vector3[0];
    private Vector3[] curvePositionsOld = new Vector3[0];


    // Update is called once per frame
    void Update()
    {
        GetPoints();
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
            //to do
        }
    }
}
