using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cleaning : MonoBehaviour
{
    NavMeshAgent agent;
    [HideInInspector]
    public GameObject trash;
    private AnimationTest animationTest;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animationTest = GetComponent<AnimationTest>();
    }

    public void CleanTrash()
    {
        if (trash == null)
            return;

        agent.SetDestination(trash.transform.position);

        if (agent.remainingDistance <= 0.2f && !agent.pathPending)
        {
            float cleanDuration = 2f;
            animationTest.PlayCleanAnimation(cleanDuration);
            StartCoroutine(DestroyTrashAfter(cleanDuration));
        }
    }

    IEnumerator DestroyTrashAfter(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (trash != null)
        {
            Destroy(trash);
        }
    }
}
