using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {
    
    public int lastStandingCount;
    public Text standingDisplay;
    public GameObject pinSet;
    private Ball ball;

    private Animator animator;
    private int lastBowlCount = 10;
    private float lastChangeTime;
    private bool ballExitBox = false;
    // Use this for initialization
    void Start () {
		
	}
	
    // Update is called once per frame
    void Update()
    {
        if (ballExitBox == true)
        {
            standingDisplay.color = Color.red;
            CheckStanding();
        }
    }


    void CheckStanding()
    {
        int currentStanding = CountStanding();
        // update last standing count
        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            standingDisplay.text = lastStandingCount.ToString();
            //calls pins have settiled method
        }
        else if (Time.time - 3f > lastChangeTime)
        {
            PinsHaveSettled();
        }

    }

    void PinsHaveSettled()
    {
        int score = lastBowlCount - lastStandingCount;
        lastBowlCount = CountStanding();
        ballExitBox = false;
        standingDisplay.color = Color.green;
        lastStandingCount = -1;
        ScoreKeeper(score);
        ball.Reset();
    }

    public int CountStanding()
    {
        int standing = 0;
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;
    }
}
