using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackComputer : MonoBehaviour
{
    private HackObject hackObject;
    public GameObject text;

    private void Start()
    {
        hackObject = GetComponent<HackObject>();
    }

    private void Update()
    {
        if(hackObject.isHacked)
        {
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
    }
}
