using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotator : MonoBehaviour
{

    [SerializeField] private GameObject shoulder; //BakaDuh

    [SerializeField] private Transform toTop;
    [SerializeField] private Transform beginRot;

    public void PointForward()
	{
        StopAllCoroutines();
        StartCoroutine(LerpToPosition(toTop));
	}

    public void LowerArm()
    {
        StopAllCoroutines();
        StartCoroutine(LerpToPosition(beginRot));
    }

    IEnumerator LerpToPosition(Transform pos)
    {
        float duration = 5f;
        float time = 0;

        while (time < duration)
        {
            time += 1 / duration * Time.deltaTime;
            if (shoulder.transform.rotation != pos.rotation)
                shoulder.transform.rotation = Quaternion.Slerp(shoulder.transform.rotation, pos.rotation, time);
            else
            {
                time = 6f;
                break;
            }
            yield return null;
        }

    }
   
}
