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
            Invoke(nameof(Desactivate), resetTimer);
        }
    }
    #endregion

    #region Desactivate
    private void Desactivate()
    {
        isHacked = false;
        objRenderer.material = defaultMaterial;
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
