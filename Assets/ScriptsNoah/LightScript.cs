using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public Material initalMat;
    public Material activatedMat;

    public MeshRenderer meshRenderer;

    public HackObject hackObject;


    private void Start()
    {
        meshRenderer.material = initalMat;
    }

    private void Update()
    {
        if(hackObject.isHacked)
        {
            meshRenderer.material = activatedMat;
        }
        else
        {
            meshRenderer.material = initalMat;
        }
    }
}
