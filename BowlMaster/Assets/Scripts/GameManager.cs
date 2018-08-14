using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //create public refrences
    private Ball ball;
    private PinSetter pinSetter;
    private ScoreDisplay scoreDisplay;
    

    private List<int> bowlScores = new List<int>();
    private List<int> frameScores = new List<int>();
    private void Start()
    {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();

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
        frameScores = ScoreMaster.ScoreCumulative(bowlScores);
        foreach(int i in bowlScores)
        {
            Debug.Log(i.ToString());
        }
        foreach(int i in frameScores)
        {
            Debug.Log(i.ToString());
        }     
        scoreDisplay.DisplayScores(bowlScores);
        scoreDisplay.FillFrames(frameScores);

    }
}
