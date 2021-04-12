using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotator : MonoBehaviour
{

    [SerializeField] private GameObject shoulder; //BakaDuh

    [SerializeField] private Transform toTop;
    [SerializeField] private Transform beginRot;
    Detector detector;

    private void Start()
    {
        detector = GameObject.FindGameObjectWithTag("Manager").GetComponent<Detector>();
    }
    public bool PointForward() =>  DoCoroutine(toTop);

    public bool LowerArm()
    {
        if (DoCoroutine(beginRot))
        { detector.GetArm();
        return true; }

        else return false;
        
    }
    bool DoCoroutine(Transform myPos)
    {
        bool coroutineCheck = false;
        StartCoroutine(LerpToPosition(myPos, coroutineCheck));
         return coroutineCheck;
    }
    IEnumerator LerpToPosition(Transform pos, bool isStillRunning)
    {
        //bug: gets stuck in while loop
        Debug.Log("chode");
        float duration = 5f;
        float time = 0;
        isStillRunning = false;

        while (time < duration)
        {
            time += 1 / duration * Time.deltaTime;
            if (shoulder.transform.rotation != pos.rotation)
                shoulder.transform.rotation = Quaternion.Slerp(shoulder.transform.rotation, pos.rotation, time);
            else
            {
                isStillRunning = true;
                yield return isStillRunning;
                break;
            }
            yield return isStillRunning;
            yield return null;
            Debug.Log("still in loop");
        }

    }
   
}
