using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text standingDisplay;
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
            standingDisplay.text = CountStanding().ToString();
        }
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
        if(thingLeft.GetComponentInParent<Pin>())
        {
            Destroy(thingLeft);
        }
    }

    
}
