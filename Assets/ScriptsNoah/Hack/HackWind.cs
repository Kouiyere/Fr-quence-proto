using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackWind : HackObject
{
    public GameObject palm;

    void Update()
    {
        if(isHacked)
        {
            palm.transform.Rotate(new Vector3(0,10,0));
        }
    }
}
