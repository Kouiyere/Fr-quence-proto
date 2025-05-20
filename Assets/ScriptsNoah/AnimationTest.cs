using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationTest : MonoBehaviour
{
    public float movementThreshold = 0.1f; 

    private NavMeshAgent agent;
    public Animator animator;

    public string walkParameter = "isWalking";

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(agent.speed != 0)
        {
            animator.SetBool(walkParameter, true);
        }
        else
        {
            animator.SetBool(walkParameter, false);
        }

        Debug.Log(agent.speed);
        
    }
}
