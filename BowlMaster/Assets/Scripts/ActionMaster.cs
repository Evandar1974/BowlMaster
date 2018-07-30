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
}
 