using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBall : MonoBehaviour
{
	//deactivate ball if mouse collides
	private void OnTriggerEnter2D(Collider2D collision)
	{
		gameObject.SetActive(false);
	}
}
