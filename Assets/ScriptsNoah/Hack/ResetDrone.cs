using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDrone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Drone"))
        {
            other.GetComponent<HackObject>().Desactivate();
        }
    }
}
