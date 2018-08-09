using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster
{
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();
        int total=0;
        int frameIndex = 1;
        int bowlIndex = 0;
        int firstBowl =0;
        int secondBowl = 0;
        int thirdBowl = 0;
        int fourthBowl = 0;
        int fifthBowl = 0;

        
       
        for (int i = 0; i < rolls.Count; i += 2)
        {
            total = 0;
            bowlIndex = frameIndex * 2 - 2;
            firstBowl = rolls[bowlIndex];
            total += firstBowl;
            if(frameIndex == 10)
            {
                if(firstBowl == 10 && rolls.Count >=2)
                {
                    secondBowl = rolls[bowlIndex + 1];
                    total += secondBowl;
                    if(rolls.Count >=3)
                    {
                        thirdBowl = rolls[bowlIndex + 2];
                        total += thirdBowl;
                        frameList.Add(total);
                    }
                }
                else
                {

                }
            }
            else if (firstBowl == 10 && rolls.Count >= 3)
            {
                thirdBowl = rolls[bowlIndex + 2];
                total += thirdBowl;
                if (thirdBowl == 10 && rolls.Count >= 5)
                {
                    fifthBowl = rolls[bowlIndex + 4];
                    total += fifthBowl;
                    frameList.Add(total);
                }
                else if (rolls.Count >= 4)
                {
                    fourthBowl = rolls[bowlIndex + 3];
                    total += fourthBowl;
                    frameList.Add(total);
                }
                frameIndex++;
            }
            else if (rolls.Count >= 2)
            {
                secondBowl = rolls[bowlIndex + 1];
                total += secondBowl;
                if (firstBowl + secondBowl == 10 && rolls.Count >= 3)
                {
                    thirdBowl = rolls[bowlIndex + 2];
                    total += thirdBowl;
                    frameList.Add(total);
                }
                else
                {
                    frameList.Add(total);
                }
                frameIndex++;
            }
        }
        
        
        //return list of framescores
        return frameList;
    }
}
