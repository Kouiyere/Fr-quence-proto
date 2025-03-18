using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackFireObject : MonoBehaviour
{
    private HackObject hackObject;
    public Sprinkler sprinkler;
    public ParticleSystem hackEffect; // Assigner un prefab de particules dans l'inspecteur
    public bool isOnfire = false;
    private float resetTimer = 2;
    private float initializeTimer = 3;

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
        if (isOnfire && sprinkler.waterOn == false)
        {

            initializeTimer -= Time.deltaTime;
            if (initializeTimer <= 0 && !hackEffect.isPlaying)
            {
                hackEffect.Play();
            }
        }
        else
        {
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0)
            {
                FireDesactivate();
            }
        }
    }

    private void FireDesactivate()
    {
        hackObject.Desactivate();
        hackEffect.Stop();
        isOnfire = false;
        resetTimer = 2f;
        initializeTimer = 5f;
    }
}
