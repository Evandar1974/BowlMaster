using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster
{
    public static List<int> ScoreCumulative(List<int> rolls)
    {       
        List<int> cumulativeScore = new List<int>();
        int total = 0;
        foreach (int score in ScoreFrames(rolls))
        {
            total += score;
            cumulativeScore.Add(total);
        }
        return cumulativeScore;         
    }
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();
        int bowlIndex = 0; 
        while (bowlIndex + 1 < rolls.Count) // do this while index of rolls is lower than number of bowls
        {           
            //detect strike
            if (rolls[bowlIndex] == 10 && rolls.Count >= 3 + bowlIndex)
            {                
                frameList.Add((rolls[bowlIndex] + rolls[bowlIndex + 1] + rolls[bowlIndex + 2]));                    
                bowlIndex += 1;
            }
            //handle non strikes
            else if (rolls[bowlIndex] < 10 && rolls.Count >= 2 + bowlIndex)
            {               
                if (rolls[bowlIndex] + rolls[bowlIndex +1] == 10 && rolls.Count >= 3 + bowlIndex)
                {  //handle spare                  
                    frameList.Add((rolls[bowlIndex] + rolls[bowlIndex + 1] + rolls[bowlIndex + 2]));
                    bowlIndex += 2;
                }
                else if (rolls[bowlIndex] + rolls[bowlIndex + 1] < 10)
                {   //handle open frame
                    frameList.Add(rolls[bowlIndex] + rolls[bowlIndex + 1]);                 
                    bowlIndex += 2;
                }
                else { bowlIndex += 2; }                                      
            }// no actions so push index out of range
            else { bowlIndex += 3; }       
        }
        //return list of framescores
        return frameList;
    }
}
