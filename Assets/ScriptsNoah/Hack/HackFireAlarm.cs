using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackFireAlarm : MonoBehaviour
{
    public GameObject fireAlarm;
    public List<GameObject> fireGOs = new List<GameObject>();
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
    }

    private void Update()
    {
        foreach (GameObject fireObject in fireGOs)
        {
            if (fireObject == null)
            {
                fireGOs.Remove(fireObject);
            }
            else if (fireObject.activeSelf == true)
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
            Sprinkler sprinkler = other.gameObject.GetComponent<Sprinkler>();
            if (sprinkler.fireAlarm != this)
            {
                sprinkler.fireAlarm = this;               
            }
        }

        //if (other.gameObject.CompareTag("Enemy"))
        //{
        //    GuardStateMachine guardStateMachine = other.gameObject.GetComponent<GuardStateMachine>();
        //    IngenierStateMachine ingenierStateMachine = other.gameObject.GetComponent<IngenierStateMachine>();
        //    WorkerStateMachine workerStateMachine = other.gameObject.GetComponent<WorkerStateMachine>();

        //    if (guardStateMachine != null)
        //    {
        //        guardStateMachine.fireAlarm = this;
        //    }
        //    if (ingenierStateMachine != null)
        //    {
        //        ingenierStateMachine.fireAlarm = this;
        //    }
        //    if (workerStateMachine != null)
        //    {
        //        workerStateMachine.fireAlarm = this;
        //    }
        //}

        if (other.gameObject.CompareTag("FireObject") && !fireGOs.Contains(other.gameObject))
        {
            fireGOs.Add(other.gameObject);
        }
    }

    //public void ReleaseTrigger(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Enemy"))
    //    {
    //        GuardStateMachine guardStateMachine = other.gameObject.GetComponent<GuardStateMachine>();
    //        IngenierStateMachine ingenierStateMachine = other.gameObject.GetComponent<IngenierStateMachine>();
    //        WorkerStateMachine workerStateMachine = other.gameObject.GetComponent<WorkerStateMachine>();

    //        if (guardStateMachine != null && guardStateMachine.currentState != GuardStateMachine.State.Alarm)
    //        {
    //            guardStateMachine.fireAlarm = null;
    //        }
    //        if (ingenierStateMachine != null && ingenierStateMachine.currentState != IngenierStateMachine.State.Alarm)
    //        {
    //            ingenierStateMachine.fireAlarm = null;
    //        }
    //        if (workerStateMachine != null && workerStateMachine.currentState != WorkerStateMachine.State.Alarm)
    //        {
    //            workerStateMachine.fireAlarm = null;
    //        }
    //    }
    //}
}
