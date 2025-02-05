using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class WaveMiniGameManager : MonoBehaviour
{
    public bool[] answer;
    public GameObject[] buttons;
    public bool[] buttonsBool;

    private void Awake()
    {
        buttons = GameObject.FindGameObjectsWithTag("Button");
        //Reordering array Button
        buttons = buttons.Reverse().ToArray();

        GenerateAnswer();

        //Checking for edge cases
        if (EdgeCases())
        {
            GenerateAnswer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        buttonsBool = new bool[buttons.Length];
        int index = 0;
        foreach (var button in buttons)
        {
            buttonsBool[index] = buttons[index].GetComponent<ButtonScript>().toggled;
            index++;
        }

        if (ArrayUtility.ArrayEquals(answer, buttonsBool))
        {
            Debug.Log("Correct");
        }
    }

    void GenerateAnswer()
    {
        answer = new bool[buttons.Length];

        for (int i = 0; i < answer.Length; i++)
        {
            float rand = UnityEngine.Random.Range(-1.0f, 1.0f);
            if (rand > 0)
            {
                answer[i] = true;
            }
            else
            {
                answer[i] = false;
            }
        }
    }

    bool EdgeCases()
    {
        bool[] allFalse = new bool[buttons.Length];
        for (int i = 0; i < allFalse.Length; i++)
        {
            allFalse[i] = false;
        }

        bool[] allTrue = new bool[buttons.Length];
        for(int i = 0;i < allTrue.Length; i++)
        {
            allTrue[i] = true;
        }

        if (ArrayUtility.ArrayEquals(answer, allFalse) || ArrayUtility.ArrayEquals(answer, allTrue))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
