using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class IngenierStateMachine : MonoBehaviour
{
    NavMeshAgent agent;
    public HackFireAlarm fireAlarm;
    private JobList jobList;
    private Called called;
    public Transform waitPoint;

    public enum State
    {
        Waiting,
        Called,
        Alarm,
        FireOver,
        JobDone,
        Stuck
    }

    public State currentState;

    public float walkingSpeed = 3f;
    public float runningSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        jobList = GetComponent<JobList>();
        called = GetComponent<Called>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update State
        switch (currentState)
        {
            case State.Waiting: UpdateWaiting(); break;
            case State.Called: UpdateCalled(); break;
            case State.Alarm: UpdateAlarm(); break;
            case State.FireOver: UpdateFireOver(); break;
            case State.JobDone: UpdateJobDone(); break;
            case State.Stuck: UpdateStuck(); break;
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
            case State.FireOver: ExitFireOver(); break;
            case State.JobDone: ExitJobDone(); break;
            case State.Stuck: ExitStuck(); break;
        }

        //Change current state to new state
        currentState = newState;

        //Enter new state
        switch (currentState)
        {
            case State.Waiting: EnterWaiting(); break;
            case State.Called: EnterCalled(); break;
            case State.Alarm: EnterAlarm(); break;
            case State.FireOver: EnterFireOver(); break;
            case State.JobDone: EnterJobDone(); break;
            case State.Stuck: EnterStuck(); break;
        }
    }

    #region Waiting
    private void EnterWaiting()
    {

    }

    private void UpdateWaiting()
    {
        if (jobList.jobs.Count > 0)
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

    }

    private void UpdateCalled()
    {
        if (jobList.jobs.Count > 0)
        {
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

    }

    private void UpdateAlarm()
    {

    }

    private void ExitAlarm()
    {

    }
    #endregion

    #region FireOver
    private void EnterFireOver()
    {

    }

    private void UpdateFireOver()
    {

    }

    private void ExitFireOver()
    {

    }
    #endregion

    #region JobDone
    private void EnterJobDone()
    {

    }

    private void UpdateJobDone()
    {
        if (jobList.jobs.Count > 0)
        {
            ChangeState(State.Called);
        }
        else
        {
            if (agent.remainingDistance <= 0.1f)
            {
                ChangeState(State.Waiting);
            }
            else
            {
                agent.SetDestination(waitPoint.position);                
            }
        }
    }

    private void ExitJobDone()
    {

    }
    #endregion

    #region Stuck
    private void EnterStuck()
    {

    }

    private void UpdateStuck()
    {

    }

    private void ExitStuck()
    {

    }
    #endregion
}
