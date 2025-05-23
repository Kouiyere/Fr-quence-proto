using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackChargeUI : MonoBehaviour
{
    public HackObject hackObject;
    public Image fillImage;

    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        fillImage.fillAmount = 0f;
    }

    void Update()
    {
        if (hackObject == null || fillImage == null)
            return;

        if (!hackObject.isHacked && hackObject.currentHackProgress > 0)
        {
            if (!canvas.enabled)
                canvas.enabled = true;

            float progress = hackObject.currentHackProgress / hackObject.hackDuration;
            fillImage.fillAmount = Mathf.Clamp01(progress);
        }
        else
        {
            fillImage.fillAmount = 0f;
            canvas.enabled = false;
        }

        // Billboard effect (face the camera)
        if (Camera.main != null)
        {
            transform.LookAt(Camera.main.transform);
            transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        }
    }
}