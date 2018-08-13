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
        bool again = true;
        while (bowlIndex + 1 < rolls.Count)
        {
            total = 0;
            firstBowl = rolls[bowlIndex];
            total += firstBowl;
            //detect strike
            if (firstBowl == 10 && rolls.Count >= 3 + bowlIndex)
            {
                    secondBowl = rolls[bowlIndex + 1];
                    thirdBowl = rolls[bowlIndex + 2];
                    total += secondBowl;
                    total += thirdBowl;
                    frameList.Add(total);
                    frameIndex++;
                    bowlIndex += 1;
            }
            //handle non strikes
            else if (firstBowl < 10 && rolls.Count >= 2 + bowlIndex)
            {
                secondBowl = rolls[bowlIndex + 1];
                total += secondBowl;
                //detect spare
                if (firstBowl + secondBowl == 10 && rolls.Count >= 3 + bowlIndex)
                {
                    thirdBowl = rolls[bowlIndex + 2];
                    total += thirdBowl;
                    frameList.Add(total);
                    frameIndex++;
                    bowlIndex += 2;
                }
                else if (firstBowl + secondBowl < 10)
                {
                    frameList.Add(total);
                    frameIndex++;
                    bowlIndex += 2;
                }
                else { bowlIndex += 2; }                                      
            }
            else { bowlIndex += 3; }
            //if(bowlIndex +1 >= rolls.Count)
            //{
            //    again = false;
            //}
        }
        //return list of framescores
        //debug readout to check values in list
        foreach (int i in frameList)
        {
            Debug.Log(i.ToString());
        }
        return frameList;
    }
}
