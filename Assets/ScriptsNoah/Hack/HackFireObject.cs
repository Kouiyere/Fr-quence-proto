using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackFireObject : MonoBehaviour
{
    private HackObject hackObject;
    [HideInInspector]
    public FireScriptNew fireScriptNew;
    public Sprinkler sprinkler;
    public HackWind wind;
    public ParticleSystem fireSparkles;
    public ParticleSystem fire2Sparkles;

    private Vector3 initRotationSparkles;
    private Vector3 windRotationSparkles;
    public int emitCount = 10;
    public float emitCooldown = 0.5f;
    private float nextEmitTime;
    public bool fire = false;

    private float resetTimer = 2;
    private float initializeTimer = 3;

    private void Start()
    {
        //fireScriptNew = GetComponent<FireScriptNew>();
        initRotationSparkles = new Vector3(-90, 0, 90);
        windRotationSparkles = initRotationSparkles + new Vector3(-90,0,0);
        hackObject = GetComponent<HackObject>();
        fireScriptNew = GetComponent<FireScriptNew>();

        if (fireScriptNew != null)
        {
            fireScriptNew.ResetFire();
        }
    }

    private void Update()
    {
        if (fireScriptNew.isOnFire && sprinkler.waterOn == false)
        {
            initializeTimer -= Time.deltaTime;
            if (initializeTimer <= 0 && fireScriptNew.isOnFire)
            {
                fire = true;
                fireScriptNew.SetOnFire();
            }
        }
        else
        {
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0)
            {
                fire = false;
                FireDesactivate();
            }
        }
        SparklesRotation();
    }

    private void FireDesactivate()
    {
        hackObject.Desactivate();
        fireScriptNew.ResetFire();
        resetTimer = 2f;
        initializeTimer = 5f;
    }

    private void SparklesRotation()
    {
        if (Time.time >= nextEmitTime && fireScriptNew.isOnFire)
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
