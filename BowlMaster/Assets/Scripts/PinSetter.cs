using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{    
    public GameObject pinSet;

    private Ball ball;
    private Animator animator;
    
    // Use this for initialization
    void Start ()
    {
        animator = FindObjectOfType<Animator>();     
	}
	
    public void Tidy()
    {
        animator.SetTrigger("Tidy");
    }

    public void Reset()
    {
        animator.SetTrigger("Reset");
    }

    public void RaisePins()
    {
        //raise standing pins only
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Raise();            
        }
    }

    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
            pin.GetComponent<Rigidbody>().transform.rotation = Quaternion.Euler(270f, 0f, 0f);
        }
    }
    
    public void RenewPins()
    {
        GameObject.Instantiate(pinSet, new Vector3(0f, 0.0f, 18.29f), Quaternion.Euler(0.0f,0.0f,0.0f));
    }
}
