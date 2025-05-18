using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackElecticity : HackObject
{
    public GameObject electricityParticles;
    private void Update()
    {
        if(isHacked)
        {
            electricityParticles.SetActive(true);
        }
        else
        {
            electricityParticles.SetActive(false);
        }
    }
}
