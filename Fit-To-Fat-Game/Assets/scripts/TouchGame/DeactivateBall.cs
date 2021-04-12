using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBall : MonoBehaviour
{
	bool hasRun = false;
	Action OnBallDisable;
	private void Update()
	{
		if (gameObject.activeSelf && !hasRun)
		{
			StartCoroutine(TimeToDeactivate());
			hasRun = true;
		}
	}
	 void ReturnToPool()
	{
		StopCoroutine(TimeToDeactivate());
		gameObject.transform.SetParent(null);
		hasRun = false;
		gameObject.SetActive(false);
	}

	public void AddToDisableCallback(Action callback) => OnBallDisable += callback;
	IEnumerator TimeToDeactivate()
	{
		yield return new WaitForSeconds(5);
		OnBallDisable();
		ReturnToPool();
	}
}
