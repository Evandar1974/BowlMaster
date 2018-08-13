using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster
{
    public List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();
        int total=0;
        int frameIndex = 1;
        int bowlIndex = 0;
        int firstBowl =0;
        int secondBowl = 0;
        int thirdBowl = 0;
        while (frameIndex < 11 || rolls.Count > bowlIndex)
        {
            total = 0;
            firstBowl = rolls[bowlIndex];
            total += firstBowl;
            if (firstBowl == 10 && rolls.Count >= 3 + bowlIndex )
            {
                secondBowl = rolls[bowlIndex + 1];
                thirdBowl = rolls[bowlIndex + 2];
                total += secondBowl;
                total += thirdBowl;
                frameList.Add(total);
                frameIndex++;
                bowlIndex += 1;                
            }
            else if (rolls.Count >= 2 + bowlIndex)
            {
                secondBowl = rolls[bowlIndex + 1];
                total += secondBowl;
                if (firstBowl + secondBowl == 10 && rolls.Count >= 3 + bowlIndex)
                {
                    thirdBowl = rolls[bowlIndex + 2];
                    total += thirdBowl;
                    frameList.Add(total);
                    frameIndex++;
                    bowlIndex += 2;
                }
                else
                {
                    frameList.Add(total);
                    frameIndex++;
                    bowlIndex += 2;
                }                
            }
        }
        
        
        //return list of framescores
        return frameList;
    }
}
