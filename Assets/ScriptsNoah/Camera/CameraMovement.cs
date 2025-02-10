using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 1000f;
    public float rotationLimit = 45f;
    private float currentYRotation = 0f;
    private float initialYRotation;

    void Start()
    {
        initialYRotation = transform.eulerAngles.y;
    }

    void Update()
    {
        float rotationAmount = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
        {
            currentYRotation += rotationAmount;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            currentYRotation -= rotationAmount;
        }

        currentYRotation = Mathf.Clamp(currentYRotation, -rotationLimit, rotationLimit);

        transform.rotation = Quaternion.Euler(10, initialYRotation + currentYRotation, 0);
    }
}