using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hack : HackObject
{
    public ParticleSystem particles;
    public GameObject sprite;

    private void Update()
    {
        if(isActivated)
        {
            particles.Emit(1);
            sprite.SetActive(true);
        }
        else
        {
            particles.Emit(0);
            sprite.SetActive(false);
        }
    }
}
