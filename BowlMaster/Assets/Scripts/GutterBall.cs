using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutterBall : MonoBehaviour {

    private PinSetter setter;
    private Ball ball;	// Use this for initialization
	void Start ()
    {
        setter = GameObject.FindObjectOfType<PinSetter>();
     
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
           setter.SetBallExit();
        }
    }
}
