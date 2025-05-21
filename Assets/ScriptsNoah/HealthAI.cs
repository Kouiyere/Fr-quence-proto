using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAI : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Death Settings")]
    public GameObject deathEffect; // optionnel : effet visuel à la mort
    public bool destroyOnDeath = true;

    public WorkerStateMachine stateMachine;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Appelle cette méthode pour infliger des dégâts
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

    private void Die()
    {
        isDead = true;
        stateMachine.enabled = false;

        // Exemple d’effet de mort
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

    // Permet de connaître l’état de l’ennemi
    public bool IsDead()
    {
        return isDead;
    }

    // Réinitialise la vie (utile pour le respawn)
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        isDead = false;
        gameObject.SetActive(true);
    }
}