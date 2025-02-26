using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackFireAlarm : HackObject
{

    public GameObject fireAlarm;
    public HackComputer[] computers;
    public Material fireAlarmActivated;
    public Material fireAlarmDefault;

    public float delay;
    private float timeElapsed;
    public bool alarmOn = false;

    private new void Start()
    {
        base.Start();
        InvokeRepeating(nameof(AlarmVisual), 1f,1f);
    }

    private void Update()
    {
        for(int i = 0; i < computers.Length; i++)
        {
            if (computers[i].isOnFire)
            {
                alarmOn = true;
            }
            else
            {
                alarmOn = false;
            }
        }
    }

    protected new void ActivateOrNotObject()
    {
        base.ActivateOrNotObject();

        if(isActivated)
        {
            alarmOn = true;
        }

        else
        {
            alarmOn = false;
        }
    }

    private void AlarmVisual()
    {
        if (alarmOn)
        {
            if (fireAlarm.GetComponent<MeshRenderer>().material == fireAlarmActivated)
            {
                fireAlarm.GetComponent<MeshRenderer>().material = fireAlarmDefault;
            }
            else if(fireAlarm.GetComponent<MeshRenderer>().material == fireAlarmDefault)
            {
                fireAlarm.GetComponent<MeshRenderer>().material = fireAlarmActivated;
            }
        }
        else
        {
            fireAlarm.GetComponent<MeshRenderer>().material = fireAlarmDefault;
        }
    }
}
