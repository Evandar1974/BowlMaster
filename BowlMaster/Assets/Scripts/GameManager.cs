using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //create public refrences
    public Ball ball;
    public PinSetter pinSetter;
    public PinCounter pinCounter;
    public ScoreDisplay scoreDisplay;
    private ActionMaster actionMaster = new ActionMaster();
    private ScoreMaster scoreMaster = new ScoreMaster();

    private List<int> bowlScores = new List<int>();
    private List<int> frameScores = new List<int>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BowlScore(int score)
    {
        //add score to players bowl scores list
        bowlScores.Add(score);
        //determine pinSetter action by sending score to actionMaster
        ActionMaster.Action action = actionMaster.Bowl(score);
        if (action == ActionMaster.Action.Tidy)
        {
            // reset ball
            ball.Reset();
            //set pinsetter to tidy
            pinSetter.Tidy();
            
        }
        else if (action == ActionMaster.Action.Reset)
        {
            //reset ball
            ball.Reset();
            //set pinsetter to reset
            pinSetter.Reset();
            //reset coiunt on pin counter
            pinCounter.ResetCount();

        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            //Reset Ball
            ball.Reset();
            //set pinsetter to reset
            pinSetter.Reset();
            //reset count on pincounter
            pinCounter.ResetCount();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            //reset ball
            ball.Reset();
            //set pin setter to reset
            pinSetter.Reset();
        }
        else
        {
            Debug.Log("shouldnt get here");
        }

        //pass bowl scores to scoreMaster to get Frame scores
        scoreMaster.ScoreFrames(bowlScores);
        //pass bowl and fram scores to scoreboard to display scores
        scoreDisplay.DisplayScores(bowlScores, frameScores);

    }
}
