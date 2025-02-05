using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnswerCurve : MonoBehaviour
{
    private ButtonScript[] buttonScript;
    private Transform[] points;
    public float[] finalYValues;

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

        points = gameObject.GetComponentsInChildren<Transform>();
        points = points.ToList().Skip(1).ToArray();

        finalYValues = new float[points.Length];
    }

    // Update is called once per frame
    void Update()
    {
        //récupération des valeurs des boutons actifs
        int activeButtons = 0;

        for (int i = 0; i < buttonScript.Length; i++)
        {
            if (buttonScript[i].toggled)
            {
                activeButtons++;
                for (int j = 0; j < finalYValues.Length; j++)
                {
                    finalYValues[j] = buttonScript[i].yValues[j];
                }
            }
        }

        //moyenne sur le nombre de boutons actifs
        if (activeButtons != 0)
        {
            for (int i = 0; i < finalYValues.Length; i++)
            {
                finalYValues[i] = finalYValues[i] / activeButtons;
            }
        }

        //assignation des position
        for (int i = 0; i < points.Length; i++)
        {
            points[i].position = new Vector3(points[i].position.x, finalYValues[i], 0);
        }
    }
}
