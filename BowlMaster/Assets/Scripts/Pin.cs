using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float standingThreshold = 20;
    private Quaternion rotation;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public bool IsStanding()
    {
        rotation = this.transform.rotation;
        return !((rotation.x + 90) > standingThreshold || rotation.z > standingThreshold);
    }
}
