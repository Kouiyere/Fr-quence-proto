using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DammageCollider : MonoBehaviour
{
    public Electricity electricity;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            if (electricity != null && electricity.isElectrified)
            {
                other.GetComponent<HealthAI>().TakeDamage(100);
            }
        }
    }
}
