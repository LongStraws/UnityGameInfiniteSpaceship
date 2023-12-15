using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float damageByObstacle = -1;
    public float speedAtWhichObstacleGoesDown;

    private ParticleSystem  particle;
    private SpriteRenderer spriteRenderer;
    
     private void Awake() {
        particle = GetComponentInChildren<ParticleSystem>();
    }
    private void Update()
    {
        transform.Translate(Vector2.down * (speedAtWhichObstacleGoesDown * Time.deltaTime));

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
        
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        
        if (other.CompareTag("Player"))
        {
            if(playerController.health > 0)
            {

                gameObject.GetComponent<SpriteRenderer>().enabled = false;

                gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;

                playerController.ChangeHealth(damageByObstacle);

                speedAtWhichObstacleGoesDown = speedAtWhichObstacleGoesDown - Time.deltaTime;
                if (gameObject.name == "ObstaclePlaceholderImage(Clone)")
                {
                    particle.Play();

                    if(AudioManager.instance == null){
                        return;
                    }
                    AudioManager.instance.Play("DeathSound");
                    AudioManager.instance.Play("ExplosionSound");
                }
            }        
        }
    }
}
