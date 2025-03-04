using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackDiversion : HackObject
{

    public bool diversion = false;
    public ParticleSystem particlesClassic;
    public ParticleSystem particlesWithWind;
    public HackWind wind;
    public Paper prefabPaper;

    public override void Start()
    {
        base.Start();

        InvokeRepeating(nameof(SpawnPaper), 1f, 1f);
    }

    void Update()
    {
        if(isHacked)
        {
            diversion = true;
        }
        else
        {
            diversion = false;
        }
    }

    private void SpawnPaper()
    {
        if(isHacked)
        {
            if (wind.isHacked)
            {
                prefabPaper.force = 500f;
            }
            else
            {
                prefabPaper.force = 50f;
            }
        }
        Instantiate(prefabPaper);
    }
}
