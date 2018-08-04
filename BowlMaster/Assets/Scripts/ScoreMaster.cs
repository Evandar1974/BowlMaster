using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster
{
    public List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();

        foreach (int score in rolls)
        {
            //if 1 bowl sent return empty list
            //if 2 bowls no spare return frame score
            //if spare see if 1 more bowl to add to score
            //if strike see if 2 more bowls then add to score

         

       
        }

        //return list of framescores
        return frameList;
    }
}
