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
    }

    void Update()
    {
        float rotationAmount = speed * Time.deltaTime;
        if (Input.GetAxisRaw("Horizontal") != 0 && !Input.GetKey("left") && !Input.GetKey("right"))
        {
            currentYRotation += rotationAmount * Input.GetAxisRaw("Horizontal");
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