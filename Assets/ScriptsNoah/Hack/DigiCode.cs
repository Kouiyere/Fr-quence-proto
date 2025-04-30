using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DigiCode : MonoBehaviour
{
    public TextMeshProUGUI textCode;
    public List<HackDoorLaser> laserHacks = new List<HackDoorLaser>();
    private string currentCode;
    public string secretCode;
    public int codeNbMax = 5;
    private int currentNB = 0;

    public void AddNumber(string pNumber)
    {
        if (currentNB < codeNbMax)
        {
            currentCode += pNumber;
            currentNB++;
            UpdateText();
            CheckCode(currentCode);
        }
    }

    private void CheckCode(string pCode)
    {
        if(currentNB==codeNbMax)
        {
            if (pCode == secretCode)
            {
                print("code correct");
                foreach (HackDoorLaser laser in laserHacks)
                {
                    laser.isHacked = true;
                }
            }
            else
            {
                print("code incorrect");
                Reset();
            }
        }
    }

    private void UpdateText()
    {
        textCode.text = currentCode;
    }

    public void Reset()
    {
        currentCode = "";
        currentNB = 0;
        UpdateText();
    }
}
