using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ScoreSystem : MonoBehaviour
{
    private float score = 0f;

    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
    }

  
    public void AddScore(float amount)
	{
        score += amount;
        Debug.Log("Your Score: " + score + "!!!!!");
	}
    public void ResetScore()
	{
        score = 0;
	}
}
