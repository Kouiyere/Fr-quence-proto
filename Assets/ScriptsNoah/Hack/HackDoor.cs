using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackDoor : MonoBehaviour
{
    private HackObject hackObject;
    private float closedXPos;
    private float openXPos;
    private float closedXPos2;
    private float openXPos2;

    public float openValue = 10f;
    public GameObject door1;
    public GameObject door2;

    private void Start()
    {
        hackObject = GetComponent<HackObject>();
        closedXPos = door1.transform.localPosition.x;
        openXPos = closedXPos - openValue;

        closedXPos2 = door2.transform.localPosition.x;
        openXPos2 = closedXPos2 + openValue;
    }

    public void Update()
    {
        float targetXPos1;
        float targetXPos2;
        if (hackObject.isHacked)
        {
            targetXPos1 = closedXPos;
            targetXPos2 = closedXPos2;
        }
        else
        {
            targetXPos1 = openXPos;
            targetXPos2 = openXPos2;
        }

        door1.transform.localPosition = Vector3.MoveTowards(door1.transform.localPosition,new Vector3(targetXPos1, door1.transform.localPosition.y, door1.transform.localPosition.z), Time.deltaTime*5);
        door2.transform.localPosition = Vector3.MoveTowards(door2.transform.localPosition, new Vector3(targetXPos2, door2.transform.localPosition.y, door2.transform.localPosition.z), Time.deltaTime * 5);
    }
}
