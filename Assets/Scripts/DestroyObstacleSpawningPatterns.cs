using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacleSpawningPatterns : MonoBehaviour
{
    public float timeTilDeath;
    float timeAlive;

    // Update is called once per frame
    void Update()
    {
       if(timeAlive <= 0)
       {
           timeAlive = timeTilDeath;
           Destroy(gameObject);           
       }
       else
       {
           timeAlive -= Time.deltaTime;
       }
    }
}
