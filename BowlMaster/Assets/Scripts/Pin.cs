using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    private float standingThreshold = 50f;
    private float distanceToRaise = 0.40f;
    private Vector3 rotation;
    private Rigidbody body;
	// Use this for initialization
	void Start ()
    {
        body = this.GetComponent<Rigidbody>();
	}

    public bool IsStanding()
    {
        rotation = this.transform.rotation.eulerAngles;
        float tiltX = Mathf.Abs(rotation.x - 270f);
        float tiltZ = Mathf.Abs(rotation.z);
        return (tiltX < standingThreshold && tiltZ < standingThreshold);
    }

    public void ExitArea()
    {
        Destroy(this);
    }

    public void Raise()
    {
        if (IsStanding())
        {
            Gravity(false);           
            this.transform.Translate(new Vector3(0f, distanceToRaise, 0f), Space.World);
            this.GetComponent<Rigidbody>().transform.rotation = Quaternion.Euler(270f, 0f, 0f);
        }
    }

    public void Lower()
    {
        Gravity(true);
        this.transform.Translate(new Vector3(0f, -distanceToRaise, 0f), Space.World); 
    }

    public void Gravity(bool b)
    {
        body.useGravity = b;
    }    
}

