using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster
{
    private List<int> pinFalls = new List<int>();
    private List<int> scores = new List<int>();
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public List<int> updateScores(List<int> pinFall)
    {
        foreach (int score in pinFall)
        {
            scores.Add(score);

        }

        return scores;
    }
}
