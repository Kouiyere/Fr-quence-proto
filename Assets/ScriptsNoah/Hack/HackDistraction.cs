using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HackDistraction : MonoBehaviour
{
    private HackObject hackObject;
    private Transform distractionPoint;

    // Start is called before the first frame update
    void Start()
    {
        hackObject = GetComponent<HackObject>();
        distractionPoint = transform.GetChild(0).GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hackObject.isHacked)
        {
            //Play ringtone
        }
    }

    public void PullTrigger(Collider other)
    {
        if (hackObject.isHacked && other.gameObject.TryGetComponent<WorkerStateMachine>(out WorkerStateMachine wsm))
        {
            if (wsm.currentState == WorkerStateMachine.State.Working || wsm.currentState == WorkerStateMachine.State.Cleaning)
            {
                wsm.distraction = gameObject;
                wsm.ChangeState(WorkerStateMachine.State.Distracted);
            }
        }
    }
}
