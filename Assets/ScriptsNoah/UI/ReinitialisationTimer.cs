using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReinitialisationTimer : MonoBehaviour
{
    public Image timerImage;
    public GameObject timerGroup;
    private HackObject hackObject;

    private void Start()
    {
        hackObject = GetComponent<HackObject>();
    }
    private void Update()
    {
        if(hackObject.isHacked)
        {
            timerGroup.SetActive(true);
            timerImage.fillAmount = hackObject.timer/hackObject.resetTimer;

            Camera activeCamera = Camera.main;
            if (activeCamera != null)
            {
                timerGroup.transform.LookAt(activeCamera.transform);
                timerGroup.transform.Rotate(0, 180, 0);
            }
        }
        else
        {
            timerGroup.SetActive(false);
        }
    }
}
