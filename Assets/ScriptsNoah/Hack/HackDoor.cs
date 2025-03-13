using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackDoor : MonoBehaviour
{
    private HackObject hackObject;
    private float closedYPos;
    private float openYPos;

    public float openValue = 10f;

    private void Start()
    {
        hackObject = GetComponent<HackObject>();
        closedYPos = transform.position.y;
        openYPos = closedYPos + openValue;
    }

    public void Update()
    {
        float targetYPos;
        if(hackObject.isHacked)
        {
            targetYPos = closedYPos;
        }
        else
        {
            targetYPos = openYPos;
        }

        transform.position = Vector3.MoveTowards(transform.position,new Vector3(transform.position.x, targetYPos, transform.position.z), Time.deltaTime*5);
    }
}
