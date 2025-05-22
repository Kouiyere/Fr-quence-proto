using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackRotation : MonoBehaviour
{
    private HackObject hackObject;

    public float speed = 1000f;
    public float rotationLimit = 45f;
    private float currentYRotation = 0f;
    private float initialYRotation;

    void Start()
    {
        initialYRotation = transform.eulerAngles.y;
        hackObject = GetComponent<HackObject>();
    }

    void Update()
    {
        if (hackObject.isHacked)
        {
            MoveLaser();
        }
    }

    void MoveLaser()
    {
        float rotationAmount = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentYRotation += rotationAmount;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentYRotation -= rotationAmount;
        }

        currentYRotation = Mathf.Clamp(currentYRotation, -rotationLimit, rotationLimit);

        transform.rotation = Quaternion.Euler(0, initialYRotation + currentYRotation, 0);
    }
}
