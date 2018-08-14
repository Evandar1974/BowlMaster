using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{    
    public GameObject pinSet;
    private Animator animator;
    private PinCounter pinCounter;

    // Use this for initialization
    void Start ()
    {
        animator = FindObjectOfType<Animator>();
        pinCounter = FindObjectOfType<PinCounter>();
	}
	public void PerformAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {         
            Tidy();
        }
        else if (action == ActionMaster.Action.Reset)
        {
            Reset();
            pinCounter.ResetCount();
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            Reset();
            pinCounter.ResetCount();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            Reset();
        }
        else
        {
            Debug.Log("shouldnt get here");
        }
    }
    private void Tidy()
    {
        animator.SetTrigger("Tidy");
    }

    private void Reset()
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
        }
    }
    
    public void RenewPins()
    {
        GameObject.Instantiate(pinSet, new Vector3(0f, 0.0f, 18.29f), Quaternion.Euler(0.0f,0.0f,0.0f));
    }
}
