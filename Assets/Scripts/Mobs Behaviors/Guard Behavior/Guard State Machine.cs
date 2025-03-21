using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardStateMachine : MonoBehaviour
{
    NavMeshAgent agent;
    private Patrol patrol;
    private GuardAlarm alarm;
    public HackFireAlarm fireAlarm;
    private HackDetection hackDetection;
    public JobList jobList;
    private float timer;
    private CalledGuard called;

    public enum State
    {
        Patrol,
        Frozen,
        Alert,
        Alarm,
        Called
    }

    public State currentState = State.Patrol;

    public float walkingSpeed = 3f;
    public float runningSpeed = 5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrol = GetComponent<Patrol>();
        alarm = GetComponent<GuardAlarm>();
        hackDetection = GetComponent<HackDetection>();
        called = GetComponent<CalledGuard>();
    }

    void Update()
    {
        //Update state
        switch (currentState)
        {
            case State.Patrol:
                UpdatePatrol(); break;
            case State.Frozen:
                UpdateFrozen(); break;
            case State.Alarm:
                UpdateAlarm(); break;
            case State.Alert:
                UpdateAlert(); break;
            case State.Called:
                UpdateCalled(); break;
        }
    }

    public void ChangeState(State newState)
    {
        //Exit current state
        switch (currentState)
        {
            case State.Patrol:
                ExitPatrol(); break;
            case State.Frozen:
                ExitFrozen(); break;
            case State.Alarm:
                ExitAlarm(); break;
            case State.Alert:
                ExitAlert(); break;
            case State.Called:
                ExitCalled(); break;
        }

        //Change current state to new state
        currentState = newState;

        //Enter new state
        switch (currentState)
        {
            case State.Patrol:
                EnterPatrol(); break;
            case State.Frozen:
                EnterFrozen(); break;
            case State.Alarm:
                EnterAlarm(); break;
            case State.Alert:
                EnterAlert(); break;
            case State.Called:
                EnterCalled(); break;
        }
    }

    #region Patrol
    private void EnterPatrol()
    {
        patrol.Patroling();
        agent.speed = walkingSpeed;
    }

    private void UpdatePatrol()
    {
        if (fireAlarm.alarmOn)
        {
            ChangeState(State.Alarm);
        }
        else if (called.door != null)
        {
            ChangeState(State.Called);
        }
        else if (hackDetection.CanSeeHack() != null)
        {
            if (jobList.jobs.Contains(hackDetection.CanSeeHack()))
            {
                patrol.Patroling();
            }
            else
            {
                ChangeState(State.Alert);
            }
        }
        else
        {
            patrol.Patroling();
        }
    }

    private void ExitPatrol()
    {

    }
    #endregion

    #region Frozen
    private void EnterFrozen()
    {
        agent.speed = 0;
        timer = 5f;
    }

    private void UpdateFrozen()
    {
        timer -= Time.deltaTime;

        if(timer<=0)
        {
            ChangeState(State.Patrol);
        }
    }

    private void ExitFrozen()
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
            if (fireAlarm.alarmOn)
            {
                alarm.TurnOfAlarm(fireAlarm.gameObject.transform);
            }
            else
            {
                ChangeState(State.Patrol);
            }
        }
    }

    private void ExitAlarm()
    {
        
    }

    #endregion

    #region Alert
    private void EnterAlert()
    {
        jobList.jobs.Add(hackDetection.CanSeeHack());
    }

    private void UpdateAlert()
    {
        //Call animation
        ChangeState(State.Patrol);
    }

    private void ExitAlert()
    {

    }
    #endregion

    #region Called
    private void EnterCalled()
    {

    }

    private void UpdateCalled()
    {
        if (called.door == null)
        {
            ChangeState(State.Patrol);
        }
        else
        {
            called.OnCall();           
        }
    }

    private void ExitCalled()
    {

    }
    #endregion
}
