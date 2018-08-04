using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //create public refrences
    private ActionMaster actionMaster = new ActionMaster();
    private ScoreMaster scoreMaster = new ScoreMaster();
    public Ball Ball;
    public PinSetter pinSetter;
    public PinCounter pinCounter;
    public ScoreDisplay scoreDisplay;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
