using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster
{
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();
        int total=0;
        float frameIndex = 1f;
        int first =0;
        int second = 0;
        int third = 0;
        int fourth = 0;

        first = rolls[1];
        if (first == 10)
        {
            total += first;
            third = rolls[3];
            if(third == 10)
        }
        
           

            //if 1 bowl sent return empty list
            //if 2 bowls no spare return frame score
            //if spare see if 1 more bowl to add to score
            //if strike see if 2 more bowls then add to score
            frameList.Add(total);
            

         

       
        

        //return list of framescores
        return frameList;
    }
}
