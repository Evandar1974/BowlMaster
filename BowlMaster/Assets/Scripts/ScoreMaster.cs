using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster
{
    public List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();
        int bowlIndex = 0; 
        while (bowlIndex + 1 < rolls.Count)
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
                {                    
                    frameList.Add((rolls[bowlIndex] + rolls[bowlIndex + 1] + rolls[bowlIndex + 2]));
                    bowlIndex += 2;
                }
                else if (rolls[bowlIndex] + rolls[bowlIndex + 1] < 10)
                {
                    frameList.Add(rolls[bowlIndex] + rolls[bowlIndex + 1]);                 
                    bowlIndex += 2;
                }
                else { bowlIndex += 2; }                                      
            }
            else { bowlIndex += 3; }       
        }
        //return list of framescores
        return frameList;
    }
}
