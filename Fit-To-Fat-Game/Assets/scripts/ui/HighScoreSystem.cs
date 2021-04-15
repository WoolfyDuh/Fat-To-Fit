using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreSystem : MonoBehaviour
{
	public static HighScoreSystem Instance { get; private set; }
	private static HighScoreData highScoreData = new HighScoreData();
	private static string dataAsString;

 void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);

		DontDestroyOnLoad(this.gameObject);
}
		
	private void Start()
	{
		dataAsString = InitHighscoreJSON(dataAsString, highScoreData);
	}
	private string InitHighscoreJSON(string json, HighScoreData toBeJSONified)
	{
		toBeJSONified.PlayerNamesList = new List<string>();
		toBeJSONified.PlayerScoresList = new List<float>();
		toBeJSONified.PlayerMissesList = new List<float>();

		for (int i = 0; i < 10; i++)
		{
			toBeJSONified.PlayerNamesList.Add("Your Name!");
			toBeJSONified.PlayerScoresList.Add(100f);
			toBeJSONified.PlayerMissesList.Add(9999f);
		}

		 json = JsonUtility.ToJson(toBeJSONified);
		
		return json;
	}
	public string GetHighScorePlayerName(int index)
	{
		return highScoreData.PlayerNamesList[index];
	}
	public float GetHighScorePlayerScore(int index)
	{
		return highScoreData.PlayerScoresList[index];
	}
	public float GetHighScorePlayerMiss(int index)
	{
		return highScoreData.PlayerMissesList[index];
	}
	public void UpdateHighscoreOrdered(float score, float misses, string name)
	{
		highScoreData = JsonUtility.FromJson<HighScoreData>(dataAsString);
			for(int i = 0; i < 10; i++)
				{
					if (score  > highScoreData.PlayerScoresList[i])
					{
						highScoreData.PlayerNamesList[i] = name;
						highScoreData.PlayerScoresList[i] = score;
						highScoreData.PlayerMissesList[i] = misses;
						break;
					}
					else
					{
						continue;
					}		
				}
		dataAsString = JsonUtility.ToJson(highScoreData);
		Debug.Log(dataAsString);
	}

[Serializable]
	private class HighScoreData
{
	public List<string> PlayerNamesList;
	public List<float> PlayerScoresList;
	public List<float> PlayerMissesList;
}
}
