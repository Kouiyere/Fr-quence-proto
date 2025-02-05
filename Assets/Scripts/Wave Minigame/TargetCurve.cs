using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetCurve : MonoBehaviour
{
    private bool[] answer;
    private Transform[] points;
    private ButtonScript[] buttonsScripts;
    private float[] finalYValues;

    // Start is called before the first frame update
    void Start()
    {
        answer = GameObject.FindObjectOfType<WaveMiniGameManager>().answer;

        buttonsScripts = new ButtonScript[answer.Length];
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
        //Reordering array Button1 = buttons[0]
        buttons = buttons.Reverse().ToArray();

        int iD = 0;
        foreach (var button in buttons)
        {
            buttonsScripts[iD] = button.GetComponent<ButtonScript>();
            iD++;
        }

        points = gameObject.GetComponentsInChildren<Transform>();
        //Removing the parent transform
        points = points.ToList().Skip(1).ToArray();

        finalYValues = new float[points.Length];
        int rightAnswers = 0;

        //recupération des valeurs des bonnes réponse
        for (int i = 0; i < answer.Length; i++)
        {
            if (answer[i])
            {
                rightAnswers++;
                for (int j = 0; j < finalYValues.Length; j++)
                {
                    finalYValues[j] += buttons[i].GetComponent<ButtonScript>().yValues[j];
                }
            }
        }

        //moyenne sur le nombre de bonnes réponses
        for (int i = 0; i < finalYValues.Length; i++)
        {
            finalYValues[i] = finalYValues[i] / rightAnswers;
        }

        for (int i = 0; i < points.Length; i++)
        {
            points[i].position = new Vector3(points[i].position.x, finalYValues[i], 0);
        }
    }
}
