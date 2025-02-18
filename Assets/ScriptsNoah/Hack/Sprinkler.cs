using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinkler : MonoBehaviour
{
    public HackFireAlarm fireAlarm;
    public GameObject waterSprinkler;

    private void Update()
    {
        if(fireAlarm.isActivated)
        {
            waterSprinkler.SetActive(true);
        }
        else
        {
            waterSprinkler.SetActive(false);
        }
    }
}
