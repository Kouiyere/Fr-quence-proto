using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrowth : MonoBehaviour
{
    [SerializeField] private bool isGrowing = false;
    [SerializeField] private Vector3 maxScale = new Vector3(2f, 2f, 2f);
    [SerializeField] private float growthSpeed = 1f;

    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        if (isGrowing)
        {
            GrowObject();
        }
    }

    private void GrowObject()
    {
        if (transform.localScale.x < maxScale.x || transform.localScale.y < maxScale.y || transform.localScale.z < maxScale.z)
        {
            Vector3 newScale = transform.localScale + Vector3.one * growthSpeed * Time.deltaTime;
            transform.localScale = new Vector3(
                Mathf.Min(newScale.x, maxScale.x),
                Mathf.Min(newScale.y, maxScale.y),
                Mathf.Min(newScale.z, maxScale.z)
            );
        }
    }
}

