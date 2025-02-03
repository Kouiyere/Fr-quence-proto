using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool toggled = false;
    public float[] yValues;

    private void Start()
    {
        yValues = new float[5];
        for (int i = 0; i < yValues.Length; i++)
        {
            yValues[i] = Random.Range(-4f, 4.5f);
        }
    }

    private void OnMouseDown()
    {
        toggled = !toggled;
    }
}
