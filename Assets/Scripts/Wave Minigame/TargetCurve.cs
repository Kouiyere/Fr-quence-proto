using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCurve : MonoBehaviour
{
    private bool[] answer;

    // Start is called before the first frame update
    void Start()
    {
        answer = GameObject.FindObjectOfType<WaveMiniGameManager>().answer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
