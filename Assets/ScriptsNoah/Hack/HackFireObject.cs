using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackFireObject : MonoBehaviour
{
    private HackObject hackObject;
    public Sprinkler sprinkler;
    public HackWind wind;
    public ParticleSystem hackEffect;
    public ParticleSystem fireSparkles;
    public ParticleSystem fire2Sparkles;

    private Vector3 initRotationSparkles;
    private Vector3 windRotationSparkles;
    public int emitCount = 10;
    public float emitCooldown = 0.5f;
    private float nextEmitTime;


    public bool isOnfire = false;
    private float resetTimer = 2;
    private float initializeTimer = 3;

    private void Start()
    {
        initRotationSparkles = new Vector3(-90, 0, 90);
        windRotationSparkles = initRotationSparkles + new Vector3(-90,0,0);
        hackObject = GetComponent<HackObject>();

        if (hackEffect != null)
        {
            hackEffect.Stop();
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
        SparklesRotation();
    }

    private void FireDesactivate()
    {
        hackObject.Desactivate();
        hackEffect.Stop();
        isOnfire = false;
        resetTimer = 2f;
        initializeTimer = 5f;
    }

    private void SparklesRotation()
    {
        if (Time.time >= nextEmitTime && hackEffect.isPlaying) // Vérifie si le cooldown est écoulé
        {
            if (wind.GetComponent<HackObject>().isHacked)
            {
                //fireSparkles.transform.rotation = Quaternion.Euler(windRotationSparkles.x, windRotationSparkles.y, windRotationSparkles.z);
                fire2Sparkles.Emit(emitCount);
                nextEmitTime = Time.time + emitCooldown;
            }
            else
            {
                //fireSparkles.transform.rotation = Quaternion.Euler(initRotationSparkles.x, initRotationSparkles.y, initRotationSparkles.z);
                fireSparkles.Emit(emitCount);
                nextEmitTime = Time.time + emitCooldown;
            }
        }
    }

}
