using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float standingThreshold = 20;
    private Vector3 rotation;
	// Use this for initialization
	void Start ()
    {
        IsStanding();
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
        print(tiltX + " " + tiltZ);
        return (tiltX < standingThreshold && tiltZ < standingThreshold);
    }
}

