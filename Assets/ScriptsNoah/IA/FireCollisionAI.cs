using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollisionAI : MonoBehaviour
{
    public bool isOnFire = false;
    public GameObject fireEffect;

    public HealthAI health;

    private void Start()
    {
        fireEffect.SetActive(false);
    }

    private void Update()
    {
        if(fireEffect.activeSelf == true && health.IsDead())
        {
            ResetFire();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            if (other.CompareTag("FireObject"))
            {
                isOnFire = true;
                fireEffect.SetActive(true);
                health.repeatDammage = true;

            }
        }
    }

    public void ResetFire()
    {
        isOnFire = false;
        fireEffect.SetActive(false);
    }
}