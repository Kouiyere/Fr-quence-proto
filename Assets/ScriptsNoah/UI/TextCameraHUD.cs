using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCameraHUD : MonoBehaviour
{
    public TextMeshProUGUI hudText;
    private Camera currentCamera;

    void Update()
    {
        Camera activeCamera = GetActiveCamera();
        if (activeCamera != currentCamera)
        {
            currentCamera = activeCamera;
            UpdateHUDText(currentCamera);
        }
    }

    Camera GetActiveCamera()
    {
        Camera[] allCameras = Camera.allCameras;
        foreach (Camera cam in allCameras)
        {
            if (cam.enabled && cam.gameObject.activeInHierarchy)
                return cam;
        }
        return null;
    }

    void UpdateHUDText(Camera cam)
    {
        if (cam == null || hudText == null) return;

        CameraInfo info = cam.GetComponent<CameraInfo>();
        if (info != null)
            hudText.text = info.cameraText;
        else
            hudText.text = "";
    }
}