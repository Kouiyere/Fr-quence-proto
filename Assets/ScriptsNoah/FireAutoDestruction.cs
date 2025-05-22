using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAutoDestruction : MonoBehaviour
{
    public float requiredDistance = 3f;
    public string targetScriptName = "FirePropagation";

    public float minDelay = 0.5f;
    public float maxDelay = 1f;

    private float destructionDelay;
    private bool timerStarted = false;

    void Start()
    {
        destructionDelay = Random.Range(minDelay, maxDelay);
    }

    void Update()
    {
        if (timerStarted)
            return;

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
            timerStarted = true;
            Invoke(nameof(DestroySelf), destructionDelay);
        }
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}