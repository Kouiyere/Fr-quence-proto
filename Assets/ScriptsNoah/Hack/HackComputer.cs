using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackComputer : HackObject
{
    public ParticleSystem fireEffect;
    public int hackIndex = 0;
    public float timer = 5f;

    public Transform workPoint;
    public bool isOnFire = false;

    private void Update()
    {
        ParticlesSpawn();
    }

    private void ParticlesSpawn()
    { 
        if(!fireEffect.isEmitting && isOnFire)
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

    protected new void OnMouseDown()
    {
        base.OnMouseDown();
        Invoke(nameof(ActiveFire), timer);
    }

    private void ActiveFire()
    {
        isOnFire = true;
    }
}
