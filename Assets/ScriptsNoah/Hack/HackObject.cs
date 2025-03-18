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
    public bool autoDesactivation = true;

    public float resetTimer = 10f;
    public float timer = 0;

    public virtual void Start()
    {
        objRenderer = GetComponent<Renderer>();

        if (objRenderer != null && defaultMaterial != null)
        {
            objRenderer.material = defaultMaterial;
        }
    }

    public virtual void Update()
    {
    }

    #region Activate
    private void Activate()
    {
        isHacked = true;
        objRenderer.material = activatedMaterial;
        if(autoDesactivation)
        {
            Invoke(nameof(Timer), 1);
        }
    }
    #endregion

    #region Desactivate
    public void Desactivate()
    {
        timer = 0;
        isHacked = false;
        objRenderer.material = defaultMaterial;
    }
    #endregion

    #region Timer
    private void Timer()
    {
        timer++;
        if (timer < resetTimer)
        {
            Invoke(nameof(Timer), 1);
        }
        else
        {
            Invoke(nameof(Desactivate), 1);
        }
    }
    #endregion

    private void OnMouseDown()
    {
        if(isHacked)
        {
            Desactivate();
        }
        else
        {
            Activate();
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
