using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponentInParent<HackDistraction>() != null)
        {
            gameObject.GetComponentInParent<HackDistraction>().PullTrigger(other);           
        }

        if (gameObject.GetComponentInParent<HackFireAlarm>() != null)
        {
            gameObject.GetComponentInParent<HackFireAlarm>().PullTrigger(other);
        }
    }
}
