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

    public virtual void Start()
    {
        objRenderer = GetComponent<Renderer>();

        if (objRenderer != null && defaultMaterial != null)
        {
            objRenderer.material = defaultMaterial;
        }
    }

    public virtual void OnMouseDown()
    {
        ActivateOrNotObject();
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

    public virtual void ActivateOrNotObject()
    {
        if (objRenderer != null)
        {
            isHacked = !isHacked;
            objRenderer.material = isHacked ? activatedMaterial : defaultMaterial;
        }
    }
}
