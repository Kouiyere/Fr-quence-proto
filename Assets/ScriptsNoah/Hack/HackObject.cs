using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackObject : MonoBehaviour
{
    public Material defaultMaterial;
    public Material overMaterial;
    public Material activatedMaterial;
    public Renderer objRenderer;

    public bool isHacked = false;
    public bool attractAI = false;
    public bool autoDesactivation = true;

    public float resetTimer = 10f;
    public float timer = 0;

    public string playSoundName;

    [Header("Hacking Progress")]
    public float hackDuration = 2f; 
    [HideInInspector]
    public float currentHackProgress = 0f; 

    private bool isMouseOver = false;
    private bool isBeingHacked = false;

    public virtual void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isMouseOver && !isHacked && Input.GetMouseButton(0))
        {
            isBeingHacked = true;
            currentHackProgress += Time.deltaTime;

            if (currentHackProgress >= hackDuration)
            {
                Activate();
                isBeingHacked = false;
                currentHackProgress = 0f;
            }
        }
        else if (!Input.GetMouseButton(0))
        {
            isBeingHacked = false;
            currentHackProgress = 0f;
        }
    }

    #region Activate
    public void Activate()
    {
        isHacked = true;

        if (playSoundName != null)
            AudioManager.Instance.PlayLoopingSound(playSoundName);

        if (autoDesactivation)
            Invoke(nameof(Timer), 1);
    }
    #endregion

    #region Desactivate
    public void Desactivate()
    {
        timer = 0;
        isHacked = false;

        if (playSoundName != null)
            AudioManager.Instance.StopLoopingSound(playSoundName);
    }
    #endregion

    #region Timer
    private void Timer()
    {
        timer++;
        if (timer < resetTimer)
            Invoke(nameof(Timer), 1);
        else
            Invoke(nameof(Desactivate), 0.25f);
    }
    #endregion

    private void OnMouseEnter() => isMouseOver = true;

    private void OnMouseExit()
    {
        isMouseOver = false;
        currentHackProgress = 0f;
    }

    private void OnMouseDown()
    {
        if (isHacked)
        {
            Desactivate();
            AudioManager.Instance.PlaySound("HackObject", transform.position);
        }
    }
}