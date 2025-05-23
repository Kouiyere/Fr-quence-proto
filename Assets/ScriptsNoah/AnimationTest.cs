using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationTest : MonoBehaviour
{
    public float movementThreshold = 0.1f; 

    private NavMeshAgent agent;
    public Animator animator;
    public HealthAI health;

    public string walkParameter = "isWalking";
    public string deathTrigger = "Die";

    private bool isDead = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isDead) return;

        if (health.currentHealth > 0)
        {
            bool isMoving = agent.velocity.magnitude > movementThreshold;
            animator.SetBool(walkParameter, isMoving);
        }
        else
        {
            HandleDeath();
        }

    }

    void HandleDeath()
    {
        isDead = true;

        animator.SetBool(walkParameter, false);
        animator.SetTrigger(deathTrigger);      

        agent.isStopped = true;                 
        agent.enabled = false;                  
    }
}
