using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAI : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Death Settings")]
    public GameObject deathEffect;
    public bool destroyOnDeath = true;

    public WorkerStateMachine stateMachine;

    private bool isDead = false;
    public bool repeatDammage = false;

    void Start()
    {
        currentHealth = maxHealth;
        InvokeRepeating(nameof(RepeatDammage), 1f, 1f);
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void RepeatDammage()
    {
        if(repeatDammage)
        {
            TakeDamage(10);
        }
    }

    private void Die()
    {
        isDead = true;
        stateMachine.enabled = false;

        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        /*
        // Désactive ou détruit l'objet
        if (destroyOnDeath)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
        */
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        isDead = false;
        gameObject.SetActive(true);
    }
}