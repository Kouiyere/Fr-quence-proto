using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class IngenierStateMachine : MonoBehaviour
{
    NavMeshAgent agent;
    public HackFireAlarm fireAlarm;
    private AlarmSearch alarmSearch;
    private IADetection iaDetection;
    [HideInInspector]
    public GameObject fireGO;
    private JobList jobList;
    private CalledInge called;
    public Transform waitPoint;
    private Stuck stuck;
    private GameObject blockingDoor;
    private FireControl fireControl;

    public enum State
    {
        Waiting,
        Called,
        Alarm,
        JobDone,
        Stuck,
        FireControl
    }

    public State currentState;

    public float walkingSpeed = 3f;
    public float runningSpeed = 5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        jobList = GetComponent<JobList>();
        called = GetComponent<CalledInge>();
        stuck = GetComponent<Stuck>();
        alarmSearch = GetComponent<AlarmSearch>();
        iaDetection = GetComponent<IADetection>();
        fireControl = GetComponent<FireControl>();
    }

    void Update()
    {
        //Update State
        switch (currentState)
        {
            case State.Waiting: UpdateWaiting(); break;
            case State.Called: UpdateCalled(); break;
            case State.Alarm: UpdateAlarm(); break;
            case State.JobDone: UpdateJobDone(); break;
            case State.Stuck: UpdateStuck(); break;
            case State.FireControl: UpdateFireControl(); break;
        }
    }

    private void ChangeState(State newState)
    {
        //Exit current State
        switch(currentState)
        {
            case State.Waiting: ExitWaiting(); break;
            case State.Called: ExitCalled(); break;
            case State.Alarm: ExitAlarm(); break;
            case State.JobDone: ExitJobDone(); break;
            case State.Stuck: ExitStuck(); break;
            case State.FireControl: ExitFireControl(); break;
        }

        //Change current state to new state
        currentState = newState;

        //Enter new state
        switch (currentState)
        {
            case State.Waiting: EnterWaiting(); break;
            case State.Called: EnterCalled(); break;
            case State.Alarm: EnterAlarm(); break;
            case State.JobDone: EnterJobDone(); break;
            case State.Stuck: EnterStuck(); break;
            case State.FireControl: EnterFireControl(); break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Door"))
        {
            blockingDoor = collision.collider.gameObject;
            ChangeState(State.Stuck);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Door"))
        {
            blockingDoor = null;
            ChangeState(State.Called);
        }
    }

    #region Waiting
    private void EnterWaiting()
    {

    }

    private void UpdateWaiting()
    {
        if (fireAlarm.alarmOn)
        {
            ChangeState(State.Alarm);
        }
        else if (jobList.jobs.Count > 0)
        {
            ChangeState(State.Called);
        }
    }

    private void ExitWaiting()
    {

    }
    #endregion

    #region Called
    private void EnterCalled()
    {
        agent.speed = walkingSpeed;
    }

    private void UpdateCalled()
    {
        if (fireAlarm.alarmOn)
        {
            ChangeState(State.Alarm);
        }
        else if (jobList.jobs.Count > 0)
        {
            if (called.activeJob == null)
            {
                called.activeJob = jobList.jobs[0];
            }
            called.Working();
        }
        else
        {
            ChangeState(State.JobDone);
        }
    }

    private void ExitCalled()
    {

    }
    #endregion

    #region Alarm
    private void EnterAlarm()
    {
        agent.speed = runningSpeed;
    }

    private void UpdateAlarm()
    {
        if (fireAlarm != null)
        {
            if (!fireAlarm.alarmOn)
            {
                ChangeState(State.JobDone);
            }
            else
            {
                alarmSearch.SearchFire();
            }
        }

        if (iaDetection.SeeFire())
        {
            ChangeState(State.FireControl);
        }
    }

    private void ExitAlarm()
    {

    }
    #endregion

    #region JobDone
    private void EnterJobDone()
    {
        agent.speed = walkingSpeed;
        agent.SetDestination(waitPoint.position);                
    }

    private void UpdateJobDone()
    {
        if (jobList.jobs.Count > 0)
        {
            ChangeState(State.Called);
        }
        else if (agent.remainingDistance <= 0.1f)
        {
            ChangeState(State.Waiting);
        }
    }

    private void ExitJobDone()
    {

    }
    #endregion

    #region Stuck
    private void EnterStuck()
    {
        agent.speed = 0;
        stuck.CallGuard(blockingDoor);
    }

    private void UpdateStuck()
    {

    }

    private void ExitStuck()
    {
        stuck.CancelCall();
    }
    #endregion

    #region FireControl

    private void EnterFireControl()
    {
        fireGO = iaDetection.SeeFire();
        fireControl.fire = fireGO;
    }

    private void UpdateFireControl()
    {
        if (fireGO == null || fireGO.activeSelf == false)
        {
            ChangeState(State.Alarm);
        }
        else
        {
            fireControl.ExtinguishFire();
        }
    }

    private void ExitFireControl()
    {

    }
    #endregion
}
