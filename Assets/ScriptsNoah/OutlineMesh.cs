using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineMesh : MonoBehaviour
{
    private Outline[] outlines;
    public HackObject hackObject;

    public Color hackedColor;
    public Color initialColor;

    private bool canReset;

    void Start()
    {
        outlines = GetComponentsInChildren<Outline>();
        SetOutline(false);
        InvokeRepeating(nameof(ResetOutline), 2f, 2f);
    }

    void OnMouseEnter()
    {
        SetOutline(true);
        canReset = false;
    }

    void OnMouseExit()
    {
        canReset = true;
        ResetOutline();
    }

    private void SetOutline(bool value)
    {
        foreach (var outline in outlines)
        {
            outline.enabled = value;
        }
    }

    private void ResetOutline()
    {
        if(hackObject.isHacked != true && canReset == true)
        {
            SetOutline(false);
        }
    }

}
