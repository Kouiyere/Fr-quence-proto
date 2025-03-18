using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackWind : MonoBehaviour
{
    private HackObject hackObject;
    public GameObject palm;
    public bool windActivated;
    private void Start()
    {
        hackObject = GetComponent<HackObject>();   
    }

    void Update()
    {
        if(hackObject.isHacked)
        {
            windActivated = true;
            palm.transform.Rotate(new Vector3(0,10,0));
        }
        else
        {
            windActivated = false;
        }
    }
}
