using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    // Use this for initialization
    public Vector3 launchSpec;
    public bool launched;
    private Rigidbody body;
    private AudioSource audioSource;
	void Start ()
    {
        body = this.GetComponent<Rigidbody>();
        audioSource = this.GetComponent<AudioSource>();
        body.useGravity = false;
        launched = false;
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

    // Update is called once per frame
    void Update () {
		
	}
}
