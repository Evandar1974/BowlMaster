using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    //any variables i might need
    public Text[] rollTexts, frameTexts;
    public void DisplayScores(List<int> bowls, List<int> frames)
    {
        int scoreIndex = 0;
        for(int i = 0; i<bowls.Count; i++ )
        {
            if(bowls[i] == 10 && i % 2 == 0)
            {
                rollTexts[scoreIndex].text = "X";
                rollTexts[scoreIndex + 1].text = "-";
                scoreIndex++;
            }
            else if (i % 2 == 1 && bowls[i] + bowls[i-1] == 10)
            {
                rollTexts[scoreIndex].text = "/";
            }
            else
            {
                rollTexts[scoreIndex].text = bowls[i].ToString();
            }
            scoreIndex++;
        }
        for(int i = 0; i<frames.Count; i++)
        {
            frameTexts[i].text = frames[i].ToString();
        }

    }
}
