using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackDoorLaser : MonoBehaviour
{
    public bool isHacked = false;
    public GameObject doorObject;


    void Start()
    {
    }

    void Update()
    {
        if(doorObject != null)
        {
            if (isHacked == true)
            {
                doorObject.SetActive(false);
            }
            else
            {
                doorObject.SetActive(true);
            }
        }
    }
}
