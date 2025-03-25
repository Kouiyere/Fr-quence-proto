using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class SwitchEffect : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private float effectDuration = 0.25f;
    private bool isGlitching = false;

    void Start()
    {
        postProcessVolume.weight = 0f;
        TriggerGlitch();
    }

    public void TriggerGlitch()
    {
        if (!isGlitching)
            StartCoroutine(GlitchRoutine());
    }

    private IEnumerator GlitchRoutine()
    {
        print("hello");
        isGlitching = true;
        postProcessVolume.weight = 1f; 
        yield return new WaitForSeconds(effectDuration);
        postProcessVolume.weight = 0f; 
        isGlitching = false;
    }
}
