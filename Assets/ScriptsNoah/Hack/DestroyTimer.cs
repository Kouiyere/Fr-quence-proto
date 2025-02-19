using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public float timer = 5f;

    void Start()
    {
        Invoke(nameof(DestroyObject), timer);
    }

    private void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
