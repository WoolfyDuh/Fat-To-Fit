using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour
{
    [SerializeField] private ExcitementBar bar;
    // Start is called before the first frame update
    void Start()
    {
        void GameOver()
		{
            Debug.Log("Game Over!");
		}
        bar.OnMeterEmpty(GameOver);
    }
}
