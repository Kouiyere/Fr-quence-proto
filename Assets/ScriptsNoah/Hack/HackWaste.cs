using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackWaste : MonoBehaviour
{
    private ParticleCollision particleCollision;
    public bool AttractRobot;
    public bool isOnFire;

    private void Start()
    {
        particleCollision = GetComponentInParent<ParticleCollision>();
    }

    private void Update()
    {
        if(particleCollision != null)
        {
            isOnFire = particleCollision.isOnFire;
        }
    }
}
