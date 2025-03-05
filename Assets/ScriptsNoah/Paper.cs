using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    private Rigidbody rb;
    public float force = 500f;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * force + new Vector3(Random.Range(-300, 100), 0, Random.Range(-200, 200)));
    }
}
