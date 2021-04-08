using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayScore : MonoBehaviour
{
	ScoreSystem scoreSystem;
	TextMeshProUGUI tmpUI;

	private void Awake()
	{
		scoreSystem = GameObject.FindObjectOfType<ScoreSystem>();
		tmpUI = gameObject.GetComponent<TextMeshProUGUI>();
	}
	private void Start()
	{
		scoreSystem.AddFuncToScoreCallback(UpdateScoreDisplay);
		UpdateScoreDisplay();
	}

	void UpdateScoreDisplay()
	{
		tmpUI.SetText("Score: " + scoreSystem.GetScore());
	}
}
