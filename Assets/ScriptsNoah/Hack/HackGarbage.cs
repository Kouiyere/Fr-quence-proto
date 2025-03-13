using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hack : MonoBehaviour
{
    private HackObject hackObject;
    public ParticleSystem particles;
    public GameObject sprite;

    private void Start()
    {
        hackObject = GetComponent<HackObject>();
        sprite.SetActive(false);
    }

    private void Update()
    {
        if(hackObject.isHacked)
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
