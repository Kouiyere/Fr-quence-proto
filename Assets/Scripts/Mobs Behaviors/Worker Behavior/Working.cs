using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Working : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform workStation;
    public Transform[] restStops;

    public float workTime;
    public float restTime;
    private float timer;
    public enum State
    {
        Work,
        Rest,
        Travelling
    }
    public State currentState;
    public bool resting = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Work()
    {
        switch (currentState)
        {
            case State.Work: UpdateWork(); break;
            case State.Rest: UpdateRest(); break;
            case State.Travelling: UpdateTravelling(); break;
        }
    }

    public void ChangeState(State newState)
    {
        switch (currentState)
        {
            case State.Work: ExitWork(); break;
            case State.Rest: ExitRest(); break;
            case State.Travelling: ExitTravelling(); break;
        }
        currentState = newState;
        switch (currentState)
        {
            case State.Work: EnterWork(); break;
            case State.Rest: EnterRest(); break;
            case State.Travelling: EnterTravelling(); break;
        }
    }

    #region Work
    private void EnterWork()
    {
        timer = workTime;
    }
    private void UpdateWork()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ChangeState(State.Travelling);
        }
    }
    private void ExitWork()
    {
        resting = true;
    }
    #endregion

    #region Rest
    private void EnterRest()
    {
        timer = restTime;
    }
    private void UpdateRest()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ChangeState(State.Travelling);
        }
    }
    private void ExitRest()
    {
        resting = false;
    }
    #endregion

    #region Travelling
    private void EnterTravelling()
    {
        if (!resting)
        {
            agent.SetDestination(workStation.position);
        }
        else
        {
            int randomID = Random.Range(0, restStops.Length);
            agent.SetDestination(restStops[randomID].position);
        }
    }
    private void UpdateTravelling()
    {
        if (agent.remainingDistance <= 0.05f)
        {
            if (resting)
            {
                ChangeState(State.Rest);
            }
            else
            {
                ChangeState(State.Work);
            }
        }
    }
    private void ExitTravelling()
    {

    }
    #endregion
}
