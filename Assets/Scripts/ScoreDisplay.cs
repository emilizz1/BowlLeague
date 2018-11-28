﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour {

    public Text[] rollText, frameText;

    public void FillRolls(List<int> rolls)
    {
        string scoresString = FormatRolls(rolls);
        for (int i = 0; i < scoresString.Length; i++)
        {
            rollText[i].text = scoresString[i].ToString();
        }
    }



    public void FillFrames (List<int> frames)
    {
        for(int i = 0; i < frames.Count; i++)
        {
            frameText[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls)
    {
        string output = "";
        for (int i = 0; i < rolls.Count; i ++)
        {
            int box = output.Length + 1;
            if (rolls[i] == 0)
            {
                output += "-";
            }
            else if (box >= 19 && rolls[i] == 10)
            {
                output += "X";
            }
            else if (rolls[i] == 10)
            {
                output += "X ";
            }
            else if ((box % 2 == 0 || box == 21) && rolls[i - 1] + rolls[i] == 10)
            {
                output += "/";
            }
            else
            {
                output += rolls[i].ToString();
            }
        }
        return output;
    }
}