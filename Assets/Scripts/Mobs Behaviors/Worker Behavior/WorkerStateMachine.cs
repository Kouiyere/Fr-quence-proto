using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerStateMachine : MonoBehaviour
{
    NavMeshAgent agent;
    public HackFireAlarm fireAlarm;
    private Working working;
    private WorkerAlarm workerAlarm;
    private IADetection iaDetection;
    public Transform exitPoint;
    [HideInInspector]
    public GameObject distraction;

    public enum State
    {
        Working,
        Alarm,
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
        working = GetComponent<Working>();
        workerAlarm = GetComponent<WorkerAlarm>();
        iaDetection = GetComponent<IADetection>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update State
        switch (currentState)
        {
            case State.Working: UpdateWorking(); break;
            case State.Alarm: UpdateAlarm(); break;
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
            case State.Cleaning: EnterCleaning(); break;
            case State.Distracted : EnterDistracted(); break;
        }
    }

    #region Working
    private void EnterWorking()
    {
        agent.speed = walkingSpeed;
        working.resting = false;
        working.ChangeState(Working.State.Travelling);
    }

    private void UpdateWorking()
    {
        if (fireAlarm.alarmOn)
        {
            ChangeState(State.Alarm);
        }
        else if (iaDetection.SeeTrash())
        {
            ChangeState(State.Cleaning);
        }
        else
        {
            working.Work();
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
        agent.SetDestination(distraction.GetComponent<HackDistraction>().distractionPoint.position);
    }
    private void UpdateDistracted()
    {
        if (agent.remainingDistance <= 0.05f && !agent.pathPending)
        {
            transform.LookAt(new Vector3(distraction.transform.position.x, transform.position.y, distraction.transform.position.z));
        }

        if (fireAlarm != null && fireAlarm.alarmOn)
        {
            ChangeState(State.Alarm);
        }

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
