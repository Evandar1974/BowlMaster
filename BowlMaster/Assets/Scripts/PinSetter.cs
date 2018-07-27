using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public int lastStandingCount = -1;
    public Text standingDisplay;
    public GameObject pinSet;
    private Ball ball;
    private float lastChangeTime;
    private bool ballEnteredBox = false;
 
	// Use this for initialization
	void Start ()
    {
        ball = GameObject.FindObjectOfType<Ball>();
     
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ballEnteredBox == true)
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
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
        lastStandingCount = -1;
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

    private void OnTriggerEnter(Collider other)
    {
        GameObject thingHit = other.gameObject;
        if(thingHit.GetComponent<Ball>())
        {
            ballEnteredBox = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject thingLeft = other.gameObject;
        if(thingLeft.GetComponent<Pin>())
        {
            Destroy(thingLeft);
        }
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
