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
    public FireCollisionAI fireCollision;

    public string walkParameter = "isWalking";
    public string stunParameter = "isStun";
    public string fireParameter = "isOnFire";
    public string deathTrigger = "Die";

    private bool isDead = false;
    public bool isStunned = false; // Nouvelle variable de stun

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isDead)
            return;

        if (health.currentHealth <= 0)
        {
            HandleDeath();
            return;
        }

        if (isStunned)
        {
            HandleStun();
            return;
        }
        else if (!agent.enabled || agent.isStopped)
        {
            agent.enabled = true;
            agent.isStopped = false;
        }

        bool isMoving = agent.velocity.magnitude > movementThreshold;

        if (fireCollision.isOnFire)
        {
            animator.SetBool(fireParameter, isMoving);
        }
        else
        {
            animator.SetBool(walkParameter, isMoving);
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

    void HandleStun()
    {
        agent.isStopped = true;

        animator.SetBool(walkParameter, false);
        animator.SetBool(fireParameter, false);
        animator.SetBool(stunParameter, true);
    }

    public void ResetStun()
    {
        isStunned = false;
        animator.SetBool(stunParameter, false);
    }
}