using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackDiversion : MonoBehaviour
{
    private HackObject hackObject;
    public bool diversion = false;
    public ParticleSystem particlesClassic;
    public ParticleSystem particlesWithWind;
    public HackWind wind;
    public Paper prefabPaper;
    public Transform paperSpawn;

    private void Start()
    {
        hackObject = GetComponent<HackObject>();
        InvokeRepeating(nameof(SpawnPaper), 1f, 1f);
    }

    void Update()
    {
        if(hackObject.isHacked)
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
        if(hackObject.isHacked)
        {
            if (wind != null && wind.windActivated)
            {
                prefabPaper.force = 500f;
            }
            else
            {
                prefabPaper.force = 50f;
            }
            Instantiate(prefabPaper, paperSpawn);
        }
    }
}
