using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerStateMachine : MonoBehaviour
{
    NavMeshAgent agent;
    public HackFireAlarm fireAlarm;
    private Patrol patrol;
    private WorkerAlarm workerAlarm;
    public Transform exitPoint;
    public GameObject distraction;

    public enum State
    {
        Working,
        Alarm,
        Alert,
        Cleaning,
        Distracted
    }

    public State currentState;

    public float walkingSpeed = 3f;
    public float runningSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrol = GetComponent<Patrol>();
        workerAlarm = GetComponent<WorkerAlarm>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update State
        switch (currentState)
        {
            case State.Working: UpdateWorking(); break;
            case State.Alarm: UpdateAlarm(); break;
            case State.Alert: UpdateAlert(); break;
            case State.Cleaning: UpdateCleaning(); break;
            case State.Distracted: UpdateDistracted(); break;
        }
    }

    public void ChangeState(State newState)
    {
        //Exit current State
        switch(currentState)
        {
            case State.Working : ExitWorking(); break;
            case State.Alarm: ExitAlarm(); break;
            case State.Alert: ExitAlert(); break;
            case State.Cleaning: ExitCleaning(); break;
            case State.Distracted : ExitDistracted(); break;
        }

        //Change current state to new state
        currentState = newState;

        //Enter new state
        switch (currentState)
        {
            case State.Working : EnterWorking(); break;
            case State.Alarm: EnterAlarm(); break;
            case State.Alert: EnterAlert(); break;
            case State.Cleaning: EnterCleaning(); break;
            case State.Distracted : EnterDistracted(); break;
        }
    }

    #region Working
    private void EnterWorking()
    {
        agent.speed = walkingSpeed;
    }

    private void UpdateWorking()
    {
        if (fireAlarm.alarmOn)
        {
            ChangeState(State.Alarm);
        }
        else
        {
            patrol.Patroling();
        }
    }

    private void ExitWorking()
    {

    }
    #endregion

    #region Alarm
    private void EnterAlarm()
    {
        agent.speed = runningSpeed;
        workerAlarm.Flee(exitPoint);
    }

    private void UpdateAlarm()
    {
        if (!fireAlarm.alarmOn)
        {
            ChangeState(State.Working);
        }
    }

    private void ExitAlarm()
    {

    }
    #endregion

    #region Alert
    private void EnterAlert()
    {

    }

    private void UpdateAlert()
    {

    }

    private void ExitAlert()
    {

    }
    #endregion

    #region Cleaning
    private void EnterCleaning()
    {

    }

    private void UpdateCleaning()
    {

    }

    private void ExitCleaning()
    {

    }
    #endregion

    #region Distracted
    private void EnterDistracted()
    {
        agent.SetDestination(distraction.transform.position);
    }
    private void UpdateDistracted()
    {
        if (!distraction.GetComponent<HackObject>().isHacked)
        {
            ChangeState(State.Working);
        }
    }
    private void ExitDistracted()
    {
        distraction = null;
    }
    #endregion
}
