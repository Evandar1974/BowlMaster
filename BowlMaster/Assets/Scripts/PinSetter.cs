using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public int lastStandingCount = -1;
    public Text standingDisplay;

    private float lastChangeTime;
    private bool ballEnteredBox = false;
 
	// Use this for initialization
	void Start ()
    {
        
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


    
}
