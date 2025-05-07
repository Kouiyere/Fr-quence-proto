using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineMesh : MonoBehaviour
{
    private Outline[] outlines;
    public HackObject hackObject;

    public Color hackedColor;
    public Color initialColor;

    void Start()
    {
        // Récupère tous les composants Outline dans les enfants
        outlines = GetComponentsInChildren<Outline>();
        SetOutline(false);
    }

    void OnMouseEnter()
    {
        SetOutline(true);
    }

    void OnMouseExit()
    {
        SetOutline(false);
    }

    private void SetOutline(bool value)
    {
        foreach (var outline in outlines)
        {
            outline.enabled = value;
        }
    }

}
