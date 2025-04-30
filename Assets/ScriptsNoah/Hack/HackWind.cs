using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackWind : MonoBehaviour
{
    private HackObject hackObject;
    public GameObject palm;
    public GameObject wind;
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
            wind.SetActive(true);
            palm.transform.Rotate(new Vector3(0,0,15));
        }
        else
        {
            windActivated = false;
            wind.SetActive(false);
        }
    }
}
