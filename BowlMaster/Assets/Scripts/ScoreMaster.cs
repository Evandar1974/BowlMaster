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
        int bowlIndex; = frameIndex -1;
        int firstBowl =0;
        int secondBowl = 0;
        int thirdBowl = 0;
        int fourthBowl = 0;
        int fifthBowl = 0;

        bowlIndex = frameIndex * 2 - 2;
        firstBowl = rolls[bowlIndex];
        total += firstBowl;
        if (firstBowl == 10)
        {
            thirdBowl = rolls[bowlIndex + 2];
            total += thirdBowl;
            if(thirdBowl == 10)
            {
                fifthBowl = rolls[bowlIndex + 4];
                total += fifthBowl;
                frameList.Add(total);
            }
            else
            {
                fourthBowl = rolls[bowlIndex+3];
                total += fourthBowl;
                frameList.Add(total);
            }
            frameIndex++;
        }
        else
        {
            secondBowl = rolls[bowlIndex+1];
            total += secondBowl;
            if (firstBowl + secondBowl == 10)
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
        
           

            //if 1 bowl sent return empty list
            //if 2 bowls no spare return frame score
            //if spare see if 1 more bowl to add to score
            //if strike see if 2 more bowls then add to score
            frameList.Add(total);
            

         

       
        

        //return list of framescores
        return frameList;
    }
}
