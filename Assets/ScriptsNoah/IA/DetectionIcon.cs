using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectionIcon : MonoBehaviour
{
    public GameObject iconDetection;
    public Image spriteIcon;
    public Sprite defaultTexture;
    public Sprite cleanTexture;
    public Sprite talkieTexture;
    public Sprite fireTexture;

    private IADetection detection;
    public WorkerStateMachine cleaning;

    private void Start()
    {
        detection = GetComponent<IADetection>();
    }

    private void Update()
    {
        if (detection != null)
        {
            if (cleaning != null)
            {
                if (cleaning.currentState == WorkerStateMachine.State.Cleaning)
                {
                    iconDetection.SetActive(true);
                    spriteIcon.sprite = cleanTexture;
                }
                else if(detection.SeeFire() != null)
                {
                    iconDetection.SetActive(true);
                    spriteIcon.sprite = fireTexture;
                }
                else if(detection.CanSeeHack())
                {
                    iconDetection.SetActive(true);
                    spriteIcon.sprite = defaultTexture;
                }
                else
                {
                    iconDetection.SetActive(false);
                }
            }
            else
            {
                if (detection.SeeFire() != null)
                {
                    iconDetection.SetActive(true);
                    spriteIcon.sprite = fireTexture;
                }
                else if (detection.CanSeeHack())
                {
                    iconDetection.SetActive(true);
                    spriteIcon.sprite = defaultTexture;
                }
                else
                {
                    iconDetection.SetActive(false);
                }
            }
        }

            if (Camera.main != null)
        {
            iconDetection.transform.LookAt(Camera.main.transform);
            iconDetection.transform.rotation = Quaternion.LookRotation(iconDetection.transform.position - Camera.main.transform.position);
        }
    }

}
