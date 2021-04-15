using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollision : MonoBehaviour
{
    ArmRotator armRotator;
    Detector detector;
    private void Start()
    {
        armRotator = transform.parent.parent.GetComponent<ArmRotator>();
        detector = FindObjectOfType<Detector>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            armRotator.LowerArm();
            Invoke("GetArm", 0.6f);
    }
    private void GetArm() => detector.GetArm();
}
