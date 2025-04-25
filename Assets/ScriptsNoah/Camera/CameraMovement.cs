using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 1000f;
    public float rotationLimit = 45f;
    private float currentYRotation = 0f;
    private float initialYRotation;

    public bool playeSound = false;

    void Start()
    {
        initialYRotation = transform.eulerAngles.y;
        //AudioManager.Instance.PlaySound("CameraMovement", transform.position);
    }

    void Update()
    {
        float rotationAmount = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
        {
            currentYRotation += rotationAmount;
            if (!AudioManager.Instance.IsLoopingSoundPlaying("CameraMovement"))
            {
                AudioManager.Instance.PlayLoopingSound("CameraMovement", transform.position);
            }
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            currentYRotation -= rotationAmount;
            if (!AudioManager.Instance.IsLoopingSoundPlaying("CameraMovement"))
            {
                AudioManager.Instance.PlayLoopingSound("CameraMovement", transform.position);
            }
        }
        else
        {
            AudioManager.Instance.StopLoopingSound("CameraMovement");
        }
        currentYRotation = Mathf.Clamp(currentYRotation, -rotationLimit, rotationLimit);

        transform.rotation = Quaternion.Euler(25, initialYRotation + currentYRotation, 0);
    }
}