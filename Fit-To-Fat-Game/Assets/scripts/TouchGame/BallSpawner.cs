using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private float spawnrate = 1f;
    [SerializeField] private float nextTimeToSpawn;
    [SerializeField] private GameObject canvas;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextTimeToSpawn)
		{
            SpawnBalls();
            nextTimeToSpawn = Time.time + 0.5f / spawnrate;
		}
    }

    void SpawnBalls()
    {
        GameObject ball = ObjectPooling.SharedPool.GetPooledBall();
        ball.transform.SetParent(canvas.transform, false);
        ball.transform.position = new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), -1);
        ball.SetActive(true);
        Debug.Log("I GOT CALLLED AND MY POSITION IS: " + ball.transform.position);
    }
}
