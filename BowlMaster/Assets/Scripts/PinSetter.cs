using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {


    public int lastStandingCount;
    public Text standingDisplay;
    public GameObject pinSet;
    private Ball ball;

    private Animator animator;
    private int lastBowlCount = 10;
    private float lastChangeTime;
    private bool ballExitBox = false;

    private ActionMaster actionMaster = new ActionMaster();


    // Use this for initialization
    void Start ()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        animator = FindObjectOfType<Animator>();
      
     
	}
	
	// Update is called once per frame
	void Update ()
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
        else if(Time.time - 3f > lastChangeTime)
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
        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if(pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;
    }

    public void GuterBall()
    {
        ScoreKeeper(0);
    }

    private void ScoreKeeper(int score)
    {
        
        ActionMaster.Action action = actionMaster.Bowl(score);
        if(action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("Tidy");
        }
        else if(action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("Reset");
            lastBowlCount = 10;
        }
        else if(action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("Reset");
            lastBowlCount = 10;
        }
        else if(action == ActionMaster.Action.EndGame)
        {
            animator.SetTrigger("Reset");
        }
        else
        {
            Debug.Log("shouldnt get here");
        }

    }

    public void SetBallExit()
    {
        ballExitBox = true;
    }

    public void RaisePins()
    {
        //raise standing pins only
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Raise();      
            
        }
    }

    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();            
        }
    }
    
    public void RenewPins()
    {
        GameObject.Instantiate(pinSet, new Vector3(0f, 0.0f, 18.29f), Quaternion.Euler(0.0f,0.0f,0.0f));
      
        
        //renew pins
    }
}
