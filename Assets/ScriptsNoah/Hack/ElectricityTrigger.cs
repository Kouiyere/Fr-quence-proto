using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityTrigger : MonoBehaviour
{
    public HackElecticity electricalPannel;
    public GameObject electricityParticles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (electricalPannel.isHacked)
            {
                if(other.GetComponentInParent<GuardStateMachine>())
                {
                    GuardStateMachine ai = other.GetComponentInParent<GuardStateMachine>();
                    ai.ChangeState(GuardStateMachine.State.Frozen);
                }

                electricalPannel.isHacked = false;
            }
        }
        electricalPannel.objRenderer.material = electricalPannel.defaultMaterial;

    }
}
