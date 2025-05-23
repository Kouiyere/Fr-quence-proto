using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinkler : MonoBehaviour
{
    public HackFireAlarm fireAlarm;
    public GameObject waterSprinkler;
    public bool waterOn;
    private float timer = 5;

    private void Update()
    {
        if (fireAlarm != null)
        {
            if (fireAlarm.needWater==true && fireAlarm.GetComponent<HackObject>().isHacked == false)
            {
                timer -= Time.deltaTime;
                if(timer <=0)
                {
                    sprinklerActivate();
                }
            }
            else
            {
                timer = 5;
                waterSprinkler.SetActive(false);
                waterOn = false;
            }
        }
        else
        {
            Debug.Log(this.name + " is not in range of a fire alarm");
        }
    }

    private void sprinklerActivate()
    {
        waterSprinkler.SetActive(true);
        waterOn = true;
    }
}
