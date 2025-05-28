using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[System.Serializable]
public class AnimationButton
{
    public Button button;
    public AnimationClip animationClip;
    public GameObject targetObject;
    public string eventName;
}

[System.Serializable]
public class AutoPlayAnimation
{
    public AnimationClip animationClip;
    public GameObject targetObject;
}

public class HUD_Manager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private List<AnimationButton> animationButtons;

    [Header("Auto Play Animations")]
    [SerializeField] private List<AutoPlayAnimation> autoPlayAnimations;

    public TMP_Dropdown graphicsDropdown;

    private void Awake()
    {
        foreach (AutoPlayAnimation autoAnim in autoPlayAnimations)
        {
            if (autoAnim.animationClip != null && autoAnim.targetObject != null)
            {
                PlayAnimation(autoAnim.targetObject, autoAnim.animationClip, "");
            }
        }

        foreach (AnimationButton animButton in animationButtons)
        {
            if (animButton.button != null && animButton.animationClip != null && animButton.targetObject != null)
            {
                animButton.button.onClick.AddListener(() => PlayAnimation(animButton.targetObject, animButton.animationClip, animButton.eventName));
            }
        }
    }

    private void PlayAnimation(GameObject target, AnimationClip animationClip, string eventName)
    {
        Animation animation = target.GetComponent<Animation>();

        if (animation == null)
        {
            animation = target.AddComponent<Animation>();
        }

        animation.clip = animationClip;
        animation.Play();

        StartCoroutine(OnAnimationEnd(animationClip.length, eventName));
    }

    private IEnumerator OnAnimationEnd(float delay, string eventName)
    {
        yield return new WaitForSeconds(delay);
        AnimationEnded(eventName);
    }

    private void AnimationEnded(string eventName)
    {
        Debug.Log("Animation terminée !");
        if(eventName == "Play")
        {
            SceneManager.LoadScene("LD Natan");
        }
        else if(eventName == "Quit")
        {
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }

        
    }

    private void OnDestroy()
    {
        foreach (AnimationButton animButton in animationButtons)
        {
            if (animButton.button != null)
            {
                animButton.button.onClick.RemoveAllListeners();
            }
        }
    }

    public void ChangeGraphicsQuality()
    {
        QualitySettings.SetQualityLevel(graphicsDropdown.value);
    }

    public void Fullscreen()
    {
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = true;
        }
    }
}