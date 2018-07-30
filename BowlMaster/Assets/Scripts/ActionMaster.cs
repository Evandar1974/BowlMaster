using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ActionMaster
{
    public enum Action { Tidy, Reset, EndTurn, EndGame };
    private int[] bowls = new int[21];
    private int bowl = 1;
    public Action Bowl(int pins)
    {
        
        if (pins > 10 || pins < 0)
        {//check valid number of pins
            throw new UnityException("Illegal number Of Pins");
        }

        // add score
        bowls[bowl - 1] = pins;

        if(bowl ==21)
        {
            return Action.EndGame;
        }

        // handle last frame        
        if (bowl == 19 && pins == 10)
        {// final frame
            bowl += 1;
            return Action.Reset;
        }
        else if (bowl == 20)
        {
            bowl += 1;
            if (AreAllPinsKnockedDown() && pins > 0)
            {
                return Action.Reset;
            }
            else if (Bowl21Awarded())
            {
                return Action.Tidy;
            }
            else
            {
                return Action.EndGame;
            }
        }

        if (pins == 10)
        {// strike
            bowl += 2;
            return Action.EndTurn;
        }

        if (bowl % 2 != 0)
        {// single bowl
            bowl += 1;
            return Action.Tidy;
        }
        else if (bowl % 2 == 0)
        {//end of frame
            bowl += 1;
            return Action.EndTurn;
        }

        throw new UnityException("Not sure what to do");
    }
    private bool Bowl21Awarded()
    {
        return (bowls[19 - 1] + bowls[20 - 1] >= 10);
    }

    private bool AreAllPinsKnockedDown()
    {
        return ((bowls[19 - 1] + bowls[20 - 1]) % 10) == 0;
    }
}
 