using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinkler : MonoBehaviour
{
    public HackFireAlarm fireAlarm;
    private HackObject fireAlarmHackObject;
    public GameObject waterSprinkler;
    public bool waterOn;
    private float timer = 5;


    private void Start()
    {
        fireAlarmHackObject = fireAlarm.GetComponent<HackObject>();
    }

    private void Update()
    {
        if(fireAlarm.needWater==true && fireAlarmHackObject.isHacked == false)
        {
            timer -= Time.deltaTime;
            if(timer <=0)
            {
                sprinklerActivate();
            }
        }
        else
        {
            waterSprinkler.SetActive(false);
            waterOn = false;
        }
    }

    private void sprinklerActivate()
    {
        waterSprinkler.SetActive(true);
        waterOn = true;
    }
}
