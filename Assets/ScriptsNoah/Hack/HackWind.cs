using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackWind : HackObject
{
    public GameObject palm;

    void Update()
    {
        if(isActivated)
        {
            palm.transform.Rotate(new Vector3(0,1,0));
        }
    }
}
