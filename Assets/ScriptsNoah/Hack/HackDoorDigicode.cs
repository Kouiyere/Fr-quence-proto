using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackDoorDigicode : MonoBehaviour
{
    private HackObject hackObject;
    public GameObject digiCode;

    private void Start()
    {
        hackObject = GetComponent<HackObject>();
    }

    private void Update()
    {
        if(hackObject.isHacked)
        {
            digiCode.SetActive(true);
        }
        else
        {
            digiCode.SetActive(false);
        }
    }
}
