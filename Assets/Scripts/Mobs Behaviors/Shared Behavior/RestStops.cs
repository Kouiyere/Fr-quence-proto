using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestStops : MonoBehaviour
{
    public Transform[] restStops;

    private void Awake()
    {
        restStops = new Transform[transform.childCount];
        foreach (Transform child in transform)
        {
            restStops[child.GetSiblingIndex()] = child;
        }
    }
}
