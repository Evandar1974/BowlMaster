using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour
{
    private Ball ball;
    private Vector3 start, end;
    private float startTime, endTime;
	// Use this for initialization
	void Start ()
    {
        ball = this.GetComponent<Ball>();
	}
	
    public void DragStart()
    {
        start = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd()
    {
        // subtract start from end to get swipe distaance and time
        endTime = Time.time;
        end = Input.mousePosition;
        float resultTime = endTime - startTime;
        Vector3 result = end - start;
        // dived distance by time to get force
        result.z = result.y / resultTime;
        result.y = 0f;
        // fire!!!!
        ball.Launch(result);


    }
	// Update is called once per frame
	void Update ()
    {
		
	}
}
