using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityTrigger : MonoBehaviour
{
    public HackElecticity electricalPannel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GuardStateMachine ai = other.GetComponentInParent<GuardStateMachine>();
            if (electricalPannel.isHacked)
            {
                print("enter");
                ai.ChangeState(GuardStateMachine.State.Frozen);
                electricalPannel.isHacked = false;
            }
        }
        electricalPannel.objRenderer.material = electricalPannel.defaultMaterial;

    }
}
