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

    public void PullTrigger(Collider other)
    {
        if (other.gameObject.CompareTag("Sprinkler"))
        {
            Debug.Log("Sprinler detected");
            HackFireAlarm fireAlarm = other.gameObject.GetComponent<HackFireAlarm>();
            if (fireAlarm != this)
            {
                fireAlarm = this;               
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Sprinler detected");
            GuardStateMachine guardStateMachine = other.gameObject.GetComponent<GuardStateMachine>();
            IngenierStateMachine ingenierStateMachine = other.gameObject.GetComponent<IngenierStateMachine>();
            WorkerStateMachine workerStateMachine = other.gameObject.GetComponent<WorkerStateMachine>();

            if (guardStateMachine != null)
            {
                guardStateMachine.fireAlarm = this;
            }
            if (ingenierStateMachine != null)
            {
                ingenierStateMachine.fireAlarm = this;
            }
            if (workerStateMachine != null)
            {
                workerStateMachine.fireAlarm = this;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GuardStateMachine guardStateMachine = other.gameObject.GetComponent<GuardStateMachine>();
            IngenierStateMachine ingenierStateMachine = other.gameObject.GetComponent<IngenierStateMachine>();
            WorkerStateMachine workerStateMachine = other.gameObject.GetComponent<WorkerStateMachine>();

            if (guardStateMachine != null && guardStateMachine.currentState != GuardStateMachine.State.Alarm)
            {
                guardStateMachine.fireAlarm = null;
            }
            if (ingenierStateMachine != null && ingenierStateMachine.currentState != IngenierStateMachine.State.Alarm)
            {
                ingenierStateMachine.fireAlarm = null;
            }
            if (workerStateMachine != null && workerStateMachine.currentState != WorkerStateMachine.State.Alarm)
            {
                workerStateMachine.fireAlarm = null;
            }
        }
    }
}
