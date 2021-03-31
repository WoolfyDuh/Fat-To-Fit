using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBall : MonoBehaviour, IDeactivateable
{
	private void Update()
	{
		if (gameObject.activeSelf)
			StartCoroutine("TimeToDeactivate");
	}
	public void ReturnToPool()
	{
		StopCoroutine("TimeToDeactivate");
		gameObject.SetActive(false);
	}

	IEnumerator TimeToDeactivate()
	{
		yield return new WaitForSeconds(5);
		gameObject.SetActive(false);
	}
}
