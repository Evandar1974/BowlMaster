using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster
{
    private List<int> pinFalls = new List<int>();
    public List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();

        foreach (int score in rolls)
        {
            
            Debug.Log("adding score");
            frameList.Add(score);
            Debug.Log(frameList.ToString());
        }
        for(int i = 0; i < frameList.Capacity; i++ )
        {

        }


        return frameList;
    }
}
