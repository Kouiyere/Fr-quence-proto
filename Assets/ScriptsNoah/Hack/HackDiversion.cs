using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackDiversion : HackObject
{

    public bool diversion = false;
    public ParticleSystem particlesClassic;
    public ParticleSystem particlesWithWind;
    public HackWind wind;

    void Update()
    {
        if(isActivated)
        {
            diversion = true;
            if(wind.isActivated)
            {
                particlesWithWind.Emit(1);
            }
            else
            {
                particlesClassic.Emit(1);
            }
        }
        else
        {
            diversion = false;
            particlesClassic.Emit(0);
            particlesWithWind.Emit(0);
        }
    }
}
