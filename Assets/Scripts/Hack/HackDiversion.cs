using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackDiversion : HackObject
{

    public bool diversion = false;

    void Update()
    {
        if(isActivated)
        {
            diversion = true;
        }
        else
        {
            diversion = false;
        }
    }
}
