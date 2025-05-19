using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    public GameObject particles;
    public bool isElectrical = false;

    public float electricityDuration = 5f;
    private float timer = 0f;

    private void Start()
    {
        particles.SetActive(false);
    }

    private void Update()
    {
        if (isElectrical)
        {
            timer += Time.deltaTime;
            if (timer >= electricityDuration)
            {
                ResetElectricity();
            }
        }
    }

    private void OnParticleCollision(GameObject particle)
    {
        if (particle.CompareTag("ElectricParticle") && particle != particles)
        {
            SetElectrical();
        }
    }

    private void SetElectrical()
    {
        isElectrical = true;
        particles.SetActive(true);
        timer = 0f;
    }

    private void ResetElectricity()
    {
        isElectrical = false;
        particles.SetActive(false);
        timer = 0f;
    }
}