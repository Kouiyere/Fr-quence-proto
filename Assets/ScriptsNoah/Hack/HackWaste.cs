using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackWaste : MonoBehaviour
{
    private HackObject hackObject;
    public bool AttractRobot;
    public Material defaultMat;

    private void Start()
    {
        hackObject = GetComponent<HackObject>();
        hackObject.defaultMaterial = defaultMat;
    }

    private void Update()
    {
        AttractRobot = hackObject.isHacked;
    }
}
