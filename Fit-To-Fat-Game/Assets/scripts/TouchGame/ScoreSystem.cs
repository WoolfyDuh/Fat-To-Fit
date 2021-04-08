using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ScoreSystem : MonoBehaviour
{
    private Action scoreCallback;
    private float score = 0f;

    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
    }

  
    public void AddScore(float amount)
	{
        score += amount;
        scoreCallback();
	}
    public float GetScore()
	{
        return score;
	}
    public void AddFuncToScoreCallback(Action callback) => scoreCallback += callback;
    public void ResetScore() => score = 0;
}
