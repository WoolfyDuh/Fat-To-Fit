using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollision : MonoBehaviour
{
    ArmRotator armRotator;
    private void Start()
    {
        armRotator = transform.parent.parent.GetComponent<ArmRotator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            armRotator.LowerArm();
    }
}
