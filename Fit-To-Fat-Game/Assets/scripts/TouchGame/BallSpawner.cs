using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float nextTimeToSpawn;
    [SerializeField] private float spawnFrequency = 0.5f;
    [SerializeField] private GameObject canvas;
    private Vector3 RandPos = new Vector3(0, 0, 1);
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextTimeToSpawn) 
		{
            SpawnBalls();
            nextTimeToSpawn = Time.time + spawnFrequency / spawnRate;
            
		}
    }

    void SpawnBalls()
    {
        GameObject ball = ObjectPooling.SharedPool.GetPooledBall();
        ball.transform.SetParent(canvas.transform, false);
        RandPos.x = Random.Range(20f, Screen.width - 20f);
        RandPos.y = Random.Range(10f, Screen.height - 140f);
        ball.transform.position = RandPos;
        ball.SetActive(true);
    }
}
