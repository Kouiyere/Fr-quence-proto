using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hack : HackObject
{
    public ParticleSystem particles;
    public GameObject sprite;

    private void Awake()
    {
        sprite.SetActive(false);
    }

    private void Update()
    {
        if(isHacked)
        {
            particles.Emit(1);
            sprite.SetActive(true);
        }
        else
        {
            particles.Emit(0);
        }
    }
}
