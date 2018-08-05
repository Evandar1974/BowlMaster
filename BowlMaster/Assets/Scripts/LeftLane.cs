using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLane : MonoBehaviour {

    private PinCounter counter;
    private Ball ball;	// Use this for initialization
	void Start ()
    {
        counter = GameObject.FindObjectOfType<PinCounter>();     
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
           counter.SetBallExit();
        }
    }
}
