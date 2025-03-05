using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerStateMachine : MonoBehaviour
{
    NavMeshAgent agent;
    public HackFireAlarm fireAlarm;

    public enum State
    {
        Working,
        Alarm,
        Alert,
        Cleaning
    }

    public State currentState;

    public float walkingSpeed = 3f;
    public float runningSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
        }
    }

    private void ChangeState(State newState)
    {
        //Exit current State
        switch(currentState)
        {
            case State.Working : ExitWorking(); break;
            case State.Alarm: ExitAlarm(); break;
            case State.Alert: ExitAlert(); break;
            case State.Cleaning: ExitCleaning(); break;
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
        }
    }

    #region Working
    private void EnterWorking()
    {

    }

    private void UpdateWorking()
    {

    }

    private void ExitWorking()
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
}
