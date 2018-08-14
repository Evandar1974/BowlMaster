using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //create public refrences
    private Ball ball;
    private PinSetter pinSetter;
    public ScoreDisplay scoreDisplay;
    

    private List<int> bowlScores = new List<int>();
    private List<int> frameScores = new List<int>();
    private void Start()
    {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
    }
    public void BowlScore(int score)
    {
        //add score to players bowl scores list
        bowlScores.Add(score);
        //determine pinSetter action by sending score to actionMaster
        ActionMaster.Action action = ActionMaster.NextAction(bowlScores);
        pinSetter.PerformAction(action);
        ball.Reset();
        //pass bowl scores to scoreMaster to get Frame scores
        frameScores = ScoreMaster.ScoreFrames(bowlScores);
        //pass bowl and fram scores to scoreboard to display scores
        scoreDisplay.DisplayScores(bowlScores, frameScores);

    }
}
