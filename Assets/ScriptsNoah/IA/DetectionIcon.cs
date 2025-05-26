using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionIcon : MonoBehaviour
{
    public GameObject iconDetection;
    private IADetection detection;
    public WorkerStateMachine cleaning;

    private void Start()
    {
        detection = GetComponent<IADetection>();
    }

    private void Update()
    {
        if(detection.CanSeeHack() != null || detection.SeeFire() != null)
        {
            iconDetection.SetActive(true);
        }
        else
        {
            iconDetection.SetActive(false);
        }

        if (cleaning != null)
        {
            if(cleaning.currentState == WorkerStateMachine.State.Cleaning)
            {
                iconDetection.SetActive(true);
            }
            else
            {
                iconDetection.SetActive(false);
            }
        }

            if (Camera.main != null)
        {
            iconDetection.transform.LookAt(Camera.main.transform);
            iconDetection.transform.rotation = Quaternion.LookRotation(iconDetection.transform.position - Camera.main.transform.position);
        }
    }

}
