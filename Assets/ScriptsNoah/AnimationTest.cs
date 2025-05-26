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

    public GameObject stunEffect;

    public string walkParameter = "isWalking";
    public string stunParameter = "isStun";
    public string fireParameter = "isOnFire";
    public string cleanParameter = "isCleaning";
    public string deathTrigger = "Die";

    private bool isDead = false;
    public bool isStunned = false;
    public bool isCleaning = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stunEffect.SetActive(false);
    }

    void Update()
    {
        if (isDead || isCleaning)
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

        stunEffect.SetActive(true);
    }

    public void ResetStun()
    {
        isStunned = false;
        animator.SetBool(stunParameter, false);

        stunEffect.SetActive(false);
    }

    public void PlayCleanAnimation(float duration)
    {
        StartCoroutine(CleanCoroutine(duration));
    }

    IEnumerator CleanCoroutine(float duration)
    {
        isCleaning = true;
        agent.isStopped = true;
        animator.SetBool(walkParameter, false);
        animator.SetBool(cleanParameter, true);

        yield return new WaitForSeconds(duration);

        animator.SetBool(cleanParameter, false);
        agent.isStopped = false;
        isCleaning = false;
    }
}