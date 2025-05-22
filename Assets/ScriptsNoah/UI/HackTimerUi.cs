using UnityEngine;
using UnityEngine.UI;

public class HackTimerUi : MonoBehaviour
{
    public HackObject targetHackObject;     // L’objet hacké à suivre
    public Image timerImage;                // L’image circulaire

    private Canvas canvas;

    void Start()
    {
        if (timerImage != null)
            timerImage.fillAmount = 0;

        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    void Update()
    {
        if (targetHackObject == null || timerImage == null)
            return;

        if (targetHackObject.isHacked)
        {
            if (!canvas.enabled)
                canvas.enabled = true;

            float progress = 1f - (targetHackObject.timer / targetHackObject.resetTimer);
            timerImage.fillAmount = Mathf.Clamp01(progress);
        }
        else
        {
            if (canvas.enabled)
                canvas.enabled = false;
            timerImage.fillAmount = 0;
        }

        // Toujours faire en sorte que le canvas regarde la caméra (facultatif mais lisible)
        if (Camera.main != null)
        {
            transform.LookAt(Camera.main.transform);
            transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        }
    }
}