using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackWind : MonoBehaviour
{
    private HackObject hackObject;
    public GameObject palm;
    public GameObject wind;
    public bool windActivated = false;

    private void Start()
    {
        hackObject = GetComponent<HackObject>();
    }

    void Update()
    {
        if (hackObject.isHacked)
        {
            windActivated = true;
            wind.SetActive(true);
            palm.transform.Rotate(new Vector3(0, 0, 15));
        }
        else
        {
            windActivated = false;
            wind.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!windActivated) return;

        FirePropagation fire = other.GetComponent<FirePropagation>();
        if (fire != null)
        {
            fire.directionalPropagation = true;
            fire.directionTarget = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FirePropagation fire = other.GetComponent<FirePropagation>();
        if (fire != null && fire.directionTarget == this.transform)
        {
            fire.directionalPropagation = false;
            fire.directionTarget = null;
        }
    }
}
