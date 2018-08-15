using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    //any variables i might need
    public Text[] rollTexts, frameTexts;
    public void DisplayScores(List<int> bowls)
    {
        string scores = FormatRolls(bowls);
        for(int i = 0; i<scores.Length; i++)
        {
            rollTexts[i].text = scores[i].ToString(); 
        }

    }

    public void FillFrames (List<int> frames)
    {
        for(int i = 0; i < frames.Count; i++)
        {
            frameTexts[i].text = frames[i].ToString();
        }

    }
    public static string FormatRolls(List<int> rolls)
    {
        string output = "";
        for(int i = 0; i < rolls.Count; i++)
        {
            if ((rolls[i] == 10 && output.Length % 2 == 0) || (output.Length >=19 && rolls[i] ==10))
            {
                output += "X";
                if(output.Length < 19)
                {
                    output += " ";
                }
            }
            else if((output.Length % 2 == 1 || output.Length == 21) && rolls[i] + rolls[i-1] == 10)
            {
                output += "/";
            }
            else if(rolls[i] == 0)
            {
                output += "-";
            }
            else
            {
                output += rolls[i].ToString();
            }
        }
        return output;
    }
}
