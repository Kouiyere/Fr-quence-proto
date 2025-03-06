using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackObject : MonoBehaviour
{
    public Material defaultMaterial;
    public Material overMaterial;
    public Material activatedMaterial;

    public Renderer objRenderer;
    public bool isHacked = false;

    public enum State
    {
        Activate,
        Desactivate
    }

    public State currentState = State.Desactivate;

    public virtual void Start()
    {
        objRenderer = GetComponent<Renderer>();

        if (objRenderer != null && defaultMaterial != null)
        {
            objRenderer.material = defaultMaterial;
        }
    }

    void Update()
    {
        //Update state
        switch (currentState)
        {
            case State.Activate:
                UpdateActivate(); break;
            case State.Desactivate:
                UpdateDesactivate(); break;
        }
    }

    public void ChangeState(State newState)
    {
        //Exit current state
        switch (currentState)
        {
            case State.Activate:
                ExitActivate(); break;
            case State.Desactivate:
                ExitDesactivate(); break;
        }

        //Change current state to new state
        currentState = newState;

        //Enter new state
        switch (currentState)
        {
            case State.Activate:
                EnterActivate(); break;
            case State.Desactivate:
                EnterDesactivate(); break;
        }
    }

    #region Activate
    private void EnterActivate()
    {
        isHacked = true;
        objRenderer.material = activatedMaterial;
    }

    private void UpdateActivate()
    {

    }

    private void ExitActivate()
    {

    }
    #endregion

    #region Desactivate
    private void EnterDesactivate()
    {
        isHacked = false;
        objRenderer.material = defaultMaterial;
    }

    private void UpdateDesactivate()
    {
    }

    private void ExitDesactivate()
    {

    }
    #endregion

    private void OnMouseDown()
    {
        if(isHacked == true)
        {
            ChangeState(State.Desactivate);
        }
        else
        {
            ChangeState(State.Activate);
        }
    }

    private void OnMouseOver()
    {
        if (!isHacked)
        {
            objRenderer.material = overMaterial;
        }
    }
    private void OnMouseExit()
    {
        if (!isHacked)
        {
            objRenderer.material = defaultMaterial;
        }
    }
}
