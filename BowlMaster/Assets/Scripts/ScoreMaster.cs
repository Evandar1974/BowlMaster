using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster
{
    public List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();
        int total=0;
        foreach (int score in rolls)
        {
            total += score;
            //if 1 bowl sent return empty list
            //if 2 bowls no spare return frame score
            //if spare see if 1 more bowl to add to score
            //if strike see if 2 more bowls then add to score
            frameList.Add(total);
            

         

       
        }

        //return list of framescores
        return frameList;
    }
}
