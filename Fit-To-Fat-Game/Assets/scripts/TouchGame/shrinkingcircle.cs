using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrinkingcircle : MonoBehaviour
{
  [SerializeField] [Range(1f,10f)] private float duration = 5f;
	Vector2 startScale = new Vector2(2f, 2f);
	Vector2 endScale = new Vector2(1f, 1f);
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
			StartCoroutine(Shrink());
		}

    }

	IEnumerator Shrink()
	{
		float time = 0;
		tr.localScale = startScale;
		while(time < duration)
		{
		tr.localScale = Vector2.Lerp(startScale, endScale, time / duration);
			time += Time.deltaTime;
			yield return null;
		}
		tr.localScale = endScale;
	}

	public void Refresh()
	{
		isActive = false;
	}
}
