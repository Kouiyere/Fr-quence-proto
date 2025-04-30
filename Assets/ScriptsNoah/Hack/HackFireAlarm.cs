using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackFireAlarm : MonoBehaviour
{
    public GameObject fireAlarm;
    public HackFireObject[] fireObjects;
    public Material fireAlarmActivated;
    public Material fireAlarmDefault;

    public bool alarmOn = false;
    public MeshRenderer fireAlarmRenderer;

    private HackObject hackObject;

    private float timer = 0.5f;

    public bool needWater;


    private void Start()
    {
        hackObject = GetComponent<HackObject>();
        fireObjects = FindObjectsByType<HackFireObject>(FindObjectsSortMode.None);
    }

    private void Update()
    {
        foreach(HackFireObject fireObject in fireObjects)
        {
            if (fireObject.fire == true)
            {
                needWater = true;
                alarmOn = true;
                //AudioManager.Instance.PlaySound("CameraMovement", transform.position);
                //if(AudioManager.
            }
            else
            {
                needWater = false;
                alarmOn = false;
            }
        }

        if(alarmOn)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                if(fireAlarmRenderer.material == fireAlarmActivated)
                {
                    fireAlarmRenderer.material = fireAlarmDefault;
                    timer = 0.5f;
                }
                else 
                {
                    fireAlarmRenderer.material = fireAlarmActivated;
                    timer = 0.5f;
                }
            }
        }
        else
        {
            fireAlarmRenderer.material = fireAlarmDefault;
        }
    }
}
