using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    // Use this for initialization
    public float launchSpeed;

    private Rigidbody body;
    private AudioSource audioSource;
	void Start ()
    {
        body = this.GetComponent<Rigidbody>();
        audioSource = this.GetComponent<AudioSource>();

        Launch();

    }

    private void Launch()
    {
        body.velocity = new Vector3(0, 0, launchSpeed);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
