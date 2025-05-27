using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinklerEffectZone : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<FireScriptNew>())
        {
            other.GetComponent<FireScriptNew>().ResetFire();
        }
    }
}
