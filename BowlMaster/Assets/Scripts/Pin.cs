using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float standingThreshold = 5f;
    private Vector3 rotation;
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
        rotation = this.transform.rotation.eulerAngles;
        float tiltX = Mathf.Abs(rotation.x - 270f);
        float tiltZ = Mathf.Abs(rotation.z);
        return (tiltX < standingThreshold && tiltZ < standingThreshold);
    }
}

