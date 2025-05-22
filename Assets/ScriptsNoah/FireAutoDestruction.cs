using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAutoDestruction : MonoBehaviour
{
    public float requiredDistance = 10f;
    public string targetScriptName = "FireNewHack";

    void Update()
    {
        MonoBehaviour[] targets = FindObjectsOfType<MonoBehaviour>();
        bool isCloseEnough = false;

        foreach (MonoBehaviour target in targets)
        {
            if (target.GetType().Name == targetScriptName)
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance <= requiredDistance)
                {
                    isCloseEnough = true;
                    break;
                }
            }
        }

        if (!isCloseEnough)
        {
            Destroy(gameObject);
        }
    }
}