using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackComputer : MonoBehaviour
{
    private HackObject hackObject;
    public Sprinkler sprinkler;
    public ParticleSystem hackEffect; // Assigner un prefab de particules dans l'inspecteur
    public bool isOnfire = false;
    private float timer = 2; 

    private void Start()
    {
        hackObject = GetComponent<HackObject>();

        if (hackEffect != null)
        {
            hackEffect.Stop(); // S'assurer que les particules ne jouent pas au début
        }
    }

    private void Update()
    {
        if (hackObject != null && hackEffect != null)
        {
            if(sprinkler.waterOn == false)
            {
                if (hackObject.isHacked && !hackEffect.isPlaying)
                {
                    hackEffect.Play();
                    isOnfire = true;
                }
                else if (!hackObject.isHacked && hackEffect.isPlaying)
                {
                    hackEffect.Stop();
                    isOnfire = false;
                }
            }
            else
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    FireDesactivate();
                }
            }
        }
    }

    private void FireDesactivate()
    {
        hackObject.Desactivate();
        hackEffect.Stop();
        isOnfire = false;
    }
}
