using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public int lastStandingCount = -1;
    public Text standingDisplay;
    public float distanceToRaise = 40f;
    

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
        
        List<Pin> pins = new List<Pin>();
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pins.Add(pin);
            }
        }
        foreach(Pin pin in pins)
        {
            pin.GetComponent<Rigidbody>().useGravity = false;
            Vector3 pinPos = pin.transform.position; 
            pinPos.y += distanceToRaise;
            pin.transform.position = pinPos;
        }
    }

    public void LowerPins()
    {
        List<Pin> pins = new List<Pin>();
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pins.Add(pin);
            }
        }
        foreach (Pin pin in pins)
        {
            Vector3 pinPos = pin.transform.position;
            pinPos.y -= distanceToRaise;
            pin.transform.position = pinPos;
            pin.GetComponent<Rigidbody>().useGravity = true;
        }
    }
    
    public void RenewPins()
    {
        //renew pins
    }
}
