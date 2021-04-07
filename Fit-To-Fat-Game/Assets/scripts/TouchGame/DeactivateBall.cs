using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBall : MonoBehaviour
{
	private void Update()
	{
		if (gameObject.activeSelf)
			StartCoroutine(TimeToDeactivate());
	}
	public void ReturnToPool()
	{
		StopCoroutine(TimeToDeactivate());
		gameObject.SetActive(false);
	}

	IEnumerator TimeToDeactivate()
	{
		//gameObject.transform.localScale = new Vector3(50, 50, 1) ;
		yield return new WaitForSeconds(5);
		gameObject.transform.SetParent(null);
		gameObject.SetActive(false);
	}
}
