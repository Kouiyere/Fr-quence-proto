using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackComputer : HackObject
{
    public ParticleSystem fireEffect;
    public int hackIndex = 0;
    public Transform workPoint;
    public bool isOnFire = false;

    protected new void Start()
    {
        base.Start();
        InvokeRepeating(nameof(ParticlesSpawn),0.5f,0.5f);

    }

    private void ParticlesSpawn()
    { 
        if(!fireEffect.isEmitting && isActivated)
        {
            isOnFire = true;
            fireEffect.Emit(1);
        }
        else
        {
            isOnFire = false;
            fireEffect.Emit(0);
        }
    }
}
