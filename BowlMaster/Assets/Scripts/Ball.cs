using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    // Use this for initialization
    public Vector3 launchSpec;

    private Rigidbody body;
    private AudioSource audioSource;
	void Start ()
    {
        body = this.GetComponent<Rigidbody>();
        audioSource = this.GetComponent<AudioSource>();
        body.useGravity = false;
        Launch(launchSpec);
    }

    public void Launch(Vector3 velocity)
    {
        body.velocity = velocity;
        body.useGravity = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
