using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODParameterController : MonoBehaviour
{
    public string parameterName = "MyParam";
    [Range(0f, 1f)]
    public float parameterValue = 0.0f;

    private StudioEventEmitter emitter;
    private EventInstance instance;

    void Update()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        if (emitter == null || emitter.gameObject != cam.gameObject)
        {
            emitter = cam.GetComponent<StudioEventEmitter>();
            if (emitter != null)
            {
                instance = emitter.EventInstance;

                PLAYBACK_STATE playbackState;
                instance.getPlaybackState(out playbackState);
                if (playbackState != PLAYBACK_STATE.PLAYING)
                {
                    emitter.Play();
                }
            }
        }
        if (instance.isValid())
        {
            instance.setParameterByName(parameterName, parameterValue);
        }
    }
}