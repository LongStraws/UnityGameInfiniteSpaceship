using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    public float startTimeBetweenSpawn;
    float timeBetweenSpawning;
    public float minTimeBetweenSpawns = .5f;
    public float decreaseInTimeBetweenSpawns;

    private void Update()
    {
        if (timeBetweenSpawning <= 0)
        {
            int rand = Random.Range(0,obstaclePatterns.Length);
            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            timeBetweenSpawning = startTimeBetweenSpawn;
            
            if(startTimeBetweenSpawn > minTimeBetweenSpawns)
            {
                startTimeBetweenSpawn -= decreaseInTimeBetweenSpawns;
            }
        }
        else
        {
            timeBetweenSpawning -= Time.deltaTime;
        }
    }
}
