using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallSpawner spawner;
    [SerializeField] private ExcitementBar bar;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject gameCanvas;

      private float setDecay = 10f;
      private float setExcitement = 100000f; 

    // Start is called before the first frame update
    void Start()
    {
        void GameOver()
		{
            gameCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);
            Debug.Log("Game Over!");
            bar.IsPaused(true);
            spawner.IsSpawning(false);
		}
        bar.OnMeterEmpty(GameOver);

        gameOverCanvas.SetActive(false);
        gameCanvas.SetActive(true);

        bar.IsPaused(false);
        spawner.IsSpawning(true);
        spawner.SetSpawnRate(0.05f, 0.5f);
        bar.SetDecayRate(setDecay);
        bar.SetMaxExcitement(setExcitement, true);
    }

	private void Update()
	{
		switch (ScoreSystem.Instance.score)
		{
			case 100:
                bar.SetMaxExcitement(500f);
                bar.SetDecayRate(0.35f);
                spawner.SetSpawnRate(0.8f, 1.8f);
                break;

            case 500:
                bar.SetMaxExcitement(250f, true);
                bar.SetDecayRate(0.15f);
                break;
            
		}
	}
}
