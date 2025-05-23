using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HackTimerUi : MonoBehaviour
{
    public HackObject targetHackObject;  
    public Image timerImage;
    public TMP_Text timerText;              

    private Canvas canvas;

    void Start()
    {
        if (timerImage != null)
            timerImage.fillAmount = 0;

        if (timerText != null)
            timerText.text = "";

        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    void Update()
    {
        if (targetHackObject == null || timerImage == null || timerText == null)
            return;

        if (targetHackObject.isHacked)
        {
            if (!canvas.enabled)
                canvas.enabled = true;

            float progress = 1f - (targetHackObject.timer / targetHackObject.resetTimer);
            timerImage.fillAmount = Mathf.Clamp01(progress);

            float timeRemaining = Mathf.Clamp(targetHackObject.resetTimer - targetHackObject.timer, 0f, targetHackObject.resetTimer);
            timerText.text = timeRemaining.ToString(); 
        }
        else
        {
            if (canvas.enabled)
                canvas.enabled = false;

            timerImage.fillAmount = 0;
            timerText.text = "";
        }

        if (Camera.main != null)
        {
            transform.LookAt(Camera.main.transform);
            transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        }
    }
}