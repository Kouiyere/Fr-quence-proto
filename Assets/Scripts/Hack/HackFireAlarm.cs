using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackFireAlarm : HackObject
{

    public GameObject fireAlarm;
    public Material fireAlarmActivated;
    public Material fireAlarmDefault;

    public float delay;
    private float timeElapsed;
    private bool alarmOn = false;

    private void Update()
    {
        if (isActivated)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= delay)
            {
                ActivateMat();
                timeElapsed = 0;
            }
        }

        if(alarmOn == true && isActivated)
        {
            fireAlarm.GetComponent<MeshRenderer>().material = fireAlarmActivated;
        }
        else if (alarmOn == false && isActivated)
        {
            fireAlarm.GetComponent<MeshRenderer>().material = fireAlarmDefault;
        }
        else
        {
            fireAlarm.GetComponent<MeshRenderer>().material = fireAlarmDefault;
        }
    }

    private void ActivateMat()
    {
        if (alarmOn)
        {
            alarmOn = false;
        }
        else
        {
            alarmOn = true;
        }
    }
}
