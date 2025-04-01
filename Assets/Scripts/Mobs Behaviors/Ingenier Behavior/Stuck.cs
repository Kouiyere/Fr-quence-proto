using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuck : MonoBehaviour
{
    private GameObject[] guards;
    private GameObject activeGuard;

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
            if (distance < minDistance)
            {
                closestGuard = guard;
                minDistance = distance;
            }
        }

        activeGuard = closestGuard;
        activeGuard.GetComponent<CalledGuard>().door = door;
    }

    public void CancelCall()
    {
        activeGuard.GetComponent<CalledGuard>().door = null;
        activeGuard.GetComponent<GuardStateMachine>().ChangeState(GuardStateMachine.State.Patrol);
        activeGuard = null;
    }
}
