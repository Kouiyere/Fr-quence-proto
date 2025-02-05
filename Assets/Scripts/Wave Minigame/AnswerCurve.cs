using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnswerCurve : MonoBehaviour
{
    private ButtonScript[] buttonScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
        buttons = buttons.Reverse().ToArray();
        buttonScript = new ButtonScript[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            buttonScript[i] = buttons[i].GetComponent<ButtonScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
