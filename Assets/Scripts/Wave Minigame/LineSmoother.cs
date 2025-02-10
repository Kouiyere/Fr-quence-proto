using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSmoother : MonoBehaviour
{
    public static Vector3[] SmoothLine(Vector3[] inputPoints, float segmentsSize)
    {
        //create curves
        AnimationCurve curveX = new AnimationCurve();
        AnimationCurve curveY = new AnimationCurve();
        AnimationCurve curveZ = new AnimationCurve();

        //create keyframe sets
        Keyframe[] keysX = new Keyframe[inputPoints.Length];
        Keyframe[] keysY = new Keyframe[inputPoints.Length];
        Keyframe[] keysZ = new Keyframe[inputPoints.Length];

        //set keyframes
        for (int i = 0; i < inputPoints.Length; i++)
        {
            keysX[i] = new Keyframe(i, inputPoints[i].x);
            keysY[i] = new Keyframe(i, inputPoints[i].y);
            keysZ[i] = new Keyframe(i, inputPoints[i].z);
        }

        //apply keyframes to curve
        curveX.keys = keysX;
        curveY.keys = keysY;
        curveZ.keys = keysZ;

        //smooth curve tangents
        for (int i = 0; i < inputPoints.Length; i++)
        {
            curveX.SmoothTangents(i, 0);
            curveY.SmoothTangents(i, 0);
            curveZ.SmoothTangents(i, 0);
        }

        //list to store smoothed values
        List<Vector3> lineSegments = new List<Vector3>();

        //find segments in each section
        for (int i = 0; i < inputPoints.Length; i++)
        {
            //add first point
            lineSegments.Add(inputPoints[i]);

            //check if in array range
            if (i + 1 < inputPoints.Length)
            {
                //find distance to next point
                float distanceToNext = Vector3.Distance(inputPoints[i], inputPoints[i + 1]);

                //number of segments
                int segments = (int)(distanceToNext / segmentsSize);

                //add segents
                for (int j = 0; j < segments; j++)
                {
                    //interpolated time on curve
                    float time = ((float)j / (float)segments) + (float) i;

                    //sample curves to find smoothed position
                    Vector3 newSegment = new Vector3(curveX.Evaluate(time), curveY.Evaluate(time), curveZ.Evaluate(time));

                    //add to list
                    lineSegments.Add(newSegment);
                }
            }
        }
        return lineSegments.ToArray();
    }
}
