using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuck : MonoBehaviour
{
    private GameObject[] guards;

    private void Start()
    {
        GuardStateMachine[] guardSMs = GameObject.FindObjectsByType<GuardStateMachine>(FindObjectsSortMode.None);
        guards = new GameObject[guardSMs.Length];
        int id = 0;
        foreach (var guardSM in guardSMs)
        {
            guards[id] = guardSM.gameObject;
            id++;
        }
    }

    public void CallGuard(GameObject door)
    {
        GameObject closestGuard = null;
        float minDistance = Mathf.Infinity;
        foreach (var guard in guards)
        {
            float distance = Vector3.Distance(guard.transform.position, transform.position);
            if (distance < minDistance && guard.GetComponent<GuardStateMachine>().currentState == GuardStateMachine.State.Patrol)
            {
                closestGuard = guard;
                minDistance = distance;
            }
        }

        closestGuard.GetComponent<CalledGuard>().OnCall(door);
    }

    public void CancelCall()
    {

    }
}
