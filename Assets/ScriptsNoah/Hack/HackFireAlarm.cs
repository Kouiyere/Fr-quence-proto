using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackFireAlarm : MonoBehaviour
{
    public GameObject fireAlarm;
    public FireScriptNew[] fireObjects;
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
        fireObjects = FindObjectsByType<FireScriptNew>(FindObjectsSortMode.None);
    }

    private void Update()
    {
        foreach(FireScriptNew fireObject in fireObjects)
        {
            if (fireObject.isOnFire == true)
            {
                needWater = true;
                alarmOn = true;
                //AudioManager.Instance.PlaySound("CameraMovement", transform.position);
                //if(AudioManager.
                break;
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
