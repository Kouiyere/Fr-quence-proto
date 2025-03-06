using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackElecticity : HackObject
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            IA_test ai = other.GetComponent<IA_test>();
            if (isHacked)
            {
                print("enter");
            }
        }
        isHacked = false;
        objRenderer.material = defaultMaterial;

    }
}
