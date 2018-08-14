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

        return output;
    }
}
