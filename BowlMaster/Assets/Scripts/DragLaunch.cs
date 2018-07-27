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
        // and build vector3
        Vector3 launchVelocity;
        launchVelocity.z = (result.y / resultTime)/100;
        launchVelocity.x = (result.x / resultTime)/100;
        launchVelocity.y = 0f;
        
        // fire!!!!
        ball.Launch(launchVelocity);


    }

    public void MoveStart(float xNudge)
    {
        if (ball.launched == false)
        {
            Vector3 pos = ball.transform.position;
            pos.x += xNudge;
            float newX = Mathf.Clamp(pos.x, -0.50f, 0.50f);
            pos.x = newX;
            ball.transform.position = pos;
        }
    }
	// Update is called once per frame
	void Update ()
    {
		
	}
}
