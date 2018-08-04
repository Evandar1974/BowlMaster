using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //create public refrences
    private ActionMaster actionMaster = new ActionMaster();
    private ScoreMaster scoreMaster = new ScoreMaster();
    public Ball Ball;
    public PinSetter pinSetter;
    public PinCounter pinCounter;
    public ScoreDisplay scoreDisplay;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BowlScore(int score)
    {

        ActionMaster.Action action = actionMaster.Bowl(score);
        if (action == ActionMaster.Action.Tidy)
        {
            pinSetter.Tidy();
        }
        else if (action == ActionMaster.Action.Reset)
        {
            pinSetter.Reset(); 
            //lastBowlCount = 10;
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            pinSetter.Reset();
            //lastBowlCount = 10;
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            pinSetter.Reset();
        }
        else
        {
            Debug.Log("shouldnt get here");
        }

    }
}
