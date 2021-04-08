using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToScore : MonoBehaviour
{
    ScoreSystem scoreSystem;

	private void Awake()
	{
		scoreSystem = GameObject.FindObjectOfType<ScoreSystem>();
	}
	
	public void AddScore()
	{
		scoreSystem.AddScore(10f);
	}
}
