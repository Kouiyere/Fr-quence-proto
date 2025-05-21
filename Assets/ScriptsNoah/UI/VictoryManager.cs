using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    public List<HealthAI> enemies;
    public GameObject victoryScreen;
    private bool victoryAchieved = false;

    private void Start()
    {
        victoryScreen.SetActive(false);
    }

    void Update()
    {
        if (victoryAchieved) return;

        bool allDead = true;

        foreach (HealthAI enemy in enemies)
        {
            if (enemy != null && enemy.currentHealth > 0)
            {
                allDead = false;
                break;
            }
        }

        if (allDead)
        {
            victoryAchieved = true;
            TriggerVictory();
        }
    }

    void TriggerVictory()
    {
        Time.timeScale = 0f;
        if (victoryScreen != null)
            victoryScreen.SetActive(true);
        Debug.Log("Victoire !");
    }
}
