using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackElecticity : MonoBehaviour
{
    public GameObject electricityParticles;
    private HackObject hackObject;

    private void Start()
    {
        hackObject = GetComponent<HackObject>();
    }

    private void Update()
    {
        if(hackObject.isHacked)
        {
            electricityParticles.SetActive(true);
        }
        else
        {
            electricityParticles.SetActive(false);
        }
    }
}
