using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRendering : MonoBehaviour
{
    private Camera cam;
    public RenderTexture renTexMini;
    public RenderTexture renTexMain;
    public RenderBuffer renBufferMini;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (renTexMini == null || renTexMain == null)
        {
            Debug.Log("Render texture has not been assigned on " + transform.parent.gameObject.name);
        }   
    }

    void Update()
    {
        
    }
}
