using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardStateMachine : MonoBehaviour
{
    NavMeshAgent agent;
    private Patrol patrol;
    public enum State
    {
        Patrol,
        Alarm
    }

    public State currentState = State.Patrol;

    public float walkingSpeed = 3f;
    public float runningSpeed = 5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrol = GetComponent<Patrol>();
    }

    void Update()
    {
        //Update state
        switch (currentState)
        {
            case State.Patrol:
                UpdatePatrol(); break;
        }
    }

    private void changeState(State newState)
    {
        //Exit current state
        switch (currentState)
        {
            case State.Patrol:
                ExitPatrol(); break;
        }

        //Change current state to new state
        currentState = newState;

        //Enter new state
        switch (currentState)
        {
            case State.Patrol:
                EnterPatrol(); break;
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
        patrol.Patroling();
    }

    private void ExitPatrol()
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

    }

    private void ExitAlarm()
    {
        
    }

    #endregion
}
