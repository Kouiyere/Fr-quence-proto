using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRendering : MonoBehaviour
{
    private Camera cam;
    private HackObject HackObject;
    public RenderTexture renTexMini;
    public RenderTexture renTexMain;
    private RenderBuffer[] RenderBuffers;

    void Start()
    {
        cam = GetComponent<Camera>();
        HackObject = GetComponent<HackObject>();
        if (renTexMini == null || renTexMain == null)
        {
            Debug.Log("Render texture has not been assigned on " + transform.parent.gameObject.name);
        }
        RenderBuffers = new RenderBuffer[2];
        RenderBuffers[0] = renTexMini.colorBuffer;
        RenderBuffers[1] = renTexMain.colorBuffer;
    }

    void Update()
    {
        if (HackObject.isHacked)
        {
            cam.SetTargetBuffers(RenderBuffers, renTexMain.depthBuffer);
        }
        else
        {
            cam.SetTargetBuffers(renTexMini.colorBuffer, renTexMini.depthBuffer);
        }
    }
}
