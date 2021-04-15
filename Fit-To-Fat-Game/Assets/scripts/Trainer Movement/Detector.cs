using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] GameObject shoulder1;
    [SerializeField] GameObject shoulder2;
    
    private int chosenHand;

    private void Start()
    {
        chosenHand = SelectHand();
        SetArm(chosenHand);
        Debug.Log(chosenHand + "beebeeboopboop");
    }
    public int SelectHand()
    {
        int handnmbr;
         handnmbr =(int) Mathf.Round(Random.Range(0.5f, 2.4f));
        return handnmbr;
    }
    private void SetArm(int armpit)
    {
        switch (armpit)
        { 
            case 1:
                shoulder1.GetComponent<ArmRotator>().PointForward();//blue
                break;
            case 2:
                shoulder2.GetComponent<ArmRotator>().PointForward();  //red
                break;
        }
    }
    public void GetArm()
    {
        int temp = SelectHand();
        SetArm(temp);
    }
}
