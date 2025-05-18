using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    public GameObject particles;
    public bool isElectrical = false;

    private void Start()
    {
        particles.SetActive(false);    
    }

    private void OnParticleCollision(GameObject particle)
    {
        if(particle.CompareTag("ElectricParticle"))
        {
            particles.SetActive(true);
            isElectrical = true;
        }
    }

}