using System.Collections;
using System;
using UnityEngine;
using TMPro;


public class TypeWritterEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent; 
    [TextArea] public string fullText;    
    public float delay = 0.05f;

    private Coroutine typingCoroutine;

    void Start()
    {
        StartTyping();
    }

    public void StartTyping()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textComponent.text = "";
        for (int i = 0; i <= fullText.Length; i++)
        {
            textComponent.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
    }

    public void SetNewText(string newText)
    {
        fullText = newText;
        StartTyping();
    }
}