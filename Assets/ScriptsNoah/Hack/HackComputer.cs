using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackComputer : HackObject
{
    public ParticleSystem fireEffect;
    public HackWind wind;
    public int hackIndex = 0;
    public float timer = 5f;

    public Transform workPoint;
    public bool isOnFire = false;

    public override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(ParticlesSpawn), 0.25f, 0.25f);
    }

    private void ParticlesSpawn()
    { 
        if(!fireEffect.isEmitting && isOnFire)
        {
            if (wind != null && wind.isActivated)
            {
                isOnFire = true;
                fireEffect.Emit(5);
            }
            else
            {
                isOnFire = true;
                fireEffect.Emit(1);
            }
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
