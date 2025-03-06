using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackElecticity : HackObject
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GuardStateMachine ai = other.GetComponentInParent<GuardStateMachine>();
            if (isHacked)
            {
                print("enter");
                ai.ChangeState(GuardStateMachine.State.Frozen);
                isHacked = false;
            }
        }
        objRenderer.material = defaultMaterial;

    }
}
