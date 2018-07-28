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
        {
            throw new UnityException("Illegal number Of Pins");
        }
        if(pins == 10)
        {
            bowl += 2;
            return Action.EndTurn;

        }
        if(bowl % 2 != 0) 
        {
            bowl += 1;
            return Action.Tidy;
        }
        throw new UnityException("Not sure what to do");
    }
}
 