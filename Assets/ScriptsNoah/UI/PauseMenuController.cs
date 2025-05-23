using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject animationTarget;
    public AnimationClip openAnimation;
    public AnimationClip closeAnimation;

    private Animation anim;
    private bool isPaused = false;
    private bool isTransitioning = false;

    private void Start()
    {
        anim = animationTarget.GetComponent<Animation>();
        if (anim == null)
            anim = animationTarget.AddComponent<Animation>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isTransitioning)
        {
            if (!isPaused)
            {
                StartCoroutine(PlayPauseAnimation());
            }
            else
            {
                ResumeGame(); // ✅ Reprend direct, anim après
            }
        }
    }

    private IEnumerator PlayPauseAnimation()
    {
        isTransitioning = true;
        pauseCanvas.SetActive(true);

        if (openAnimation != null)
        {
            anim.AddClip(openAnimation, openAnimation.name);
            anim.Play(openAnimation.name);
            yield return new WaitForSeconds(openAnimation.length);
        }

        Time.timeScale = 0f;
        isPaused = true;
        isTransitioning = false;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        StartCoroutine(PlayResumeAnimation()); // ✅ Joue anim après
    }

    private IEnumerator PlayResumeAnimation()
    {
        isTransitioning = true;

        if (closeAnimation != null)
        {
            anim.AddClip(closeAnimation, closeAnimation.name);
            anim.Play(closeAnimation.name);
            yield return new WaitForSeconds(closeAnimation.length);
        }

        pauseCanvas.SetActive(false);
        isTransitioning = false;
    }
}