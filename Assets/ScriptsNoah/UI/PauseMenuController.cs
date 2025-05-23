using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public Animator pauseAnimator;
    public string showTriggerName = "Show";
    public string hideTriggerName = "Hide";

    public float showAnimationDuration = 0.5f; // Durée réelle de l'animation d'ouverture
    public float hideAnimationDuration = 0.5f; // Durée réelle de l'animation de fermeture

    private bool isPaused = false;
    private bool isAnimating = false;

    void Start()
    {
        // Important : l'anim doit jouer même si timeScale = 0
        if (pauseAnimator != null)
            pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isAnimating)
        {
            if (!isPaused)
                StartCoroutine(ShowPauseMenu());
            else
                StartCoroutine(HidePauseMenu());
        }
    }

    private IEnumerator ShowPauseMenu()
    {
        isAnimating = true;

        // Joue l'animation d’ouverture
        pauseAnimator.SetTrigger(showTriggerName);

        // Attends la durée réelle de l’animation, en ignorant timeScale
        yield return new WaitForSecondsRealtime(showAnimationDuration);

        Time.timeScale = 0f;
        isPaused = true;
        isAnimating = false;
    }

    private IEnumerator HidePauseMenu()
    {
        isAnimating = true;

        // On remet le temps à 1 pour permettre à l’anim de fermeture de jouer
        Time.timeScale = 1f;

        pauseAnimator.SetTrigger(hideTriggerName);

        // Attends la durée réelle de l’animation de fermeture
        yield return new WaitForSecondsRealtime(hideAnimationDuration);

        isPaused = false;
        isAnimating = false;
    }
}