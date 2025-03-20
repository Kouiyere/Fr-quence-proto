using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public GameObject firePaper;

    private void Start()
    {
        firePaper.SetActive(false);
    }
    private void OnParticleCollision(GameObject particle)
    {
        firePaper.SetActive(true);
    }
}
