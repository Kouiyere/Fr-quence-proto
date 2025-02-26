using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackFireAlarm : HackObject
{
    public GameObject fireAlarm;
    public HackComputer[] computers;
    public Material fireAlarmActivated;
    public Material fireAlarmDefault;

    public bool alarmOn = false;
    private MeshRenderer fireAlarmRenderer;

    private new void Start()
    {
        base.Start();

        if (fireAlarm != null)
        {
            fireAlarmRenderer = fireAlarm.GetComponent<MeshRenderer>();
        }

        InvokeRepeating(nameof(AlarmVisual), 1f, 1f);
    }

    private void Update()
    {
        bool isFireDetected = false;
        foreach (HackComputer computer in computers)
        {
            if (computer.isOnFire && !isActivated)
            {
                isFireDetected = true;
                break;
            }
        }

        alarmOn = isFireDetected;
    }

    protected new void ActivateOrNotObject()
    {
        base.ActivateOrNotObject();
        alarmOn = isActivated;
    }

    private void AlarmVisual()
    {
        if (fireAlarmRenderer == null) return;

        if (alarmOn)
        {
            fireAlarmRenderer.material = (fireAlarmRenderer.material == fireAlarmActivated)
                ? fireAlarmDefault
                : fireAlarmActivated;
        }
        else
        {
            fireAlarmRenderer.material = fireAlarmDefault;
        }
    }
}
