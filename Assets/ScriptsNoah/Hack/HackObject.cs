using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackObject : MonoBehaviour
{
    public Material defaultMaterial;
    public Material overMaterial;
    public Material activatedMaterial;

    public Renderer objRenderer;
    public bool isActivated = false;

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
        if (!isActivated)
        {
            objRenderer.material = overMaterial;
        }
    }
    private void OnMouseExit()
    {
        if (!isActivated)
        {
            objRenderer.material = defaultMaterial;
        }
    }

    public virtual void ActivateOrNotObject()
    {
        if (objRenderer != null)
        {
            isActivated = !isActivated;
            objRenderer.material = isActivated ? activatedMaterial : defaultMaterial;
        }
    }
}
