using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    // Use this for initialization
    
    public Vector3 launchSpec;
    public bool launched;

    private Vector3 startPosition;
    private Rigidbody body;
    private AudioSource audioSource;
	void Start ()
    {

        body = this.GetComponent<Rigidbody>();
        audioSource = this.GetComponent<AudioSource>();
        body.useGravity = false;
        launched = false;
        startPosition = this.transform.position;
        //Launch(launchSpec);
    }

    public void Launch(Vector3 velocity)
    {
        if (launched == false)
        {
            body.velocity = velocity;
            body.useGravity = true;
            audioSource.Play();
        }
        launched = true;
    }

    public void Reset()
    {
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        body.freezeRotation = true;
        body.useGravity = false;
        this.transform.position = startPosition;
        body.freezeRotation = false;
        launched = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
