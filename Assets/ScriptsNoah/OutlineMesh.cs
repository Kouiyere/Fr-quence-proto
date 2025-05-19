using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineMesh : MonoBehaviour
{
    private List<Outline> outlines = new List<Outline>();
    public HackObject hackObject;

    public Color hackedColor;
    public Color initialColor;

    void Start()
    {
        outlines.Clear();
        ApplyOutlines(transform);
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

    private void ApplyOutlines(Transform obj)
    {
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        MeshFilter meshFilter = obj.GetComponent<MeshFilter>();

        if (meshRenderer != null && meshFilter != null)
        {
            int materialCount = meshRenderer.sharedMaterials.Length;

            for (int i = 0; i < materialCount; i++)
            {
                GameObject subMeshObj = new GameObject("SubMeshOutline_" + i);
                subMeshObj.transform.SetParent(obj);
                subMeshObj.transform.localPosition = Vector3.zero;
                subMeshObj.transform.localRotation = Quaternion.identity;
                subMeshObj.transform.localScale = Vector3.one;

                MeshFilter subMeshFilter = subMeshObj.AddComponent<MeshFilter>();
                MeshRenderer subMeshRenderer = subMeshObj.AddComponent<MeshRenderer>();
                Outline outline = subMeshObj.AddComponent<Outline>();

                subMeshFilter.mesh = meshFilter.mesh;
                subMeshRenderer.sharedMaterial = meshRenderer.sharedMaterials[i];
                outline.enabled = false;

                outlines.Add(outline);
            }
        }

        foreach (Transform child in obj)
        {
            ApplyOutlines(child);
        }
    }

    private void SetOutline(bool value)
    {
        foreach (var outline in outlines)
        {
            outline.enabled = value;
        }
    }
}
