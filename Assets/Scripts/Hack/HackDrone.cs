using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackDrone : HackObject
{
    public float movementSpeed = 1f;
    public void Update()
    {
        if(isActivated)
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, -1, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 1, 0);
            }
        }
    }
}
