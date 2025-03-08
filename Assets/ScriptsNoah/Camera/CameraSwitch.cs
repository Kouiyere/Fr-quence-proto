using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : HackObject
{
    public Camera[] cameras;
    public GameObject[] cameraGO;
    private int currentCameraIndex;

    public override void Start()
    {
        base.Start();

        cameraGO = new GameObject[transform.childCount];
        int i = 0;
        foreach (Transform child in transform)
        {
            cameraGO[i++] = child.gameObject;
        }
        i = 0;
        cameras = new Camera[cameraGO.Length];
        foreach (var go in cameraGO)
        {
            cameras[i++] = go.GetComponentInChildren<Camera>();
        }

        currentCameraIndex = 0;
        ActivateCamera(currentCameraIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchToNextCamera();
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                for (int i = 0; i < cameraGO.Length; i++)
                {
                    if (hit.transform.gameObject == cameraGO[i])
                    {
                        SwitchToCamera(i);
                        break;
                    }
                }
            }
        }
    }

    void SwitchToNextCamera()
    {
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
        ActivateCamera(currentCameraIndex);
    }

    void SwitchToCamera(int index)
    {
        if (index != currentCameraIndex)
        {
            currentCameraIndex = index;
            ActivateCamera(currentCameraIndex);
        }
    }

    void ActivateCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == index);
        }
    }
}
