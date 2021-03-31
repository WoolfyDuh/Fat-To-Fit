using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrinkingcircle : MonoBehaviour
{
    private float time = 5f;
	Vector2 startScale = new Vector2(2, 2);
    private Transform tr;
	bool isActive = false;

	private void Awake()
	{
		tr = gameObject.GetComponent<Transform>();
		tr.localScale = startScale;
	}
	// Update is called once per frame
	void Update()
    {
        
		if (gameObject.activeSelf && !isActive)
		{
			isActive = true;
			StartCoroutine("Shrink");
		}


    }

	IEnumerator Shrink()
	{
		for(int i = 0; i < time; i++)
		{
			Vector2 minus = new Vector2((0.2f * i), (0.2f * i));
			Vector2 result = startScale - minus;
			Vector2 newScale = result;
			tr.localScale = newScale;
			yield return new WaitForSeconds(0.8f);
		}
		Disappear();
	}

	void Disappear()
	{
		StopCoroutine("Shrink");
		isActive = false;
		gameObject.SetActive(false);
	}
}
