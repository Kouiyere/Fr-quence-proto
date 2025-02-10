using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRoute : MonoBehaviour
{
    public Transform[] waypointArray;

    private void Awake()
    {
        waypointArray = new Transform[transform.childCount];
        AddChildrenInArray();
    }

    void AddChildrenInArray()
    {
        int id = 0;
        foreach (Transform child in transform)
        {
            waypointArray[id] = child.transform;
            id++;
        }
    }
}
