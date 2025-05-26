using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPropagationCollider : MonoBehaviour
{
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (!windActivated) return;

        FirePropagation fire = other.GetComponent<FirePropagation>();
        if (fire != null)
        {
            fire.directionalPropagation = true;
            fire.directionTarget = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FirePropagation fire = other.GetComponent<FirePropagation>();
        if (fire != null && fire.directionTarget == this.transform)
        {
            fire.directionalPropagation = false;
            fire.directionTarget = null;
        }
    }
    */
}
