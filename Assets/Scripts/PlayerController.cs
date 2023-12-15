using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class PlayerController : MonoBehaviour
{
    private Vector2 targetPosition = new Vector2(0, -4);
    public float moveIncrement;
    public float speed;
    public float maxCharacterCanGoRight;
    public float minCharacterCanGoLeft;
    Sprite thisSprite;

    public float maxHealth;
    public float health {get {return currentHealth;}}

    public float currentHealth;
    public static float zAxisPosition;

    public RestartAndStart restartAndStartScript;

    public GameObject deathCanvas;
    public bool isActivated1 = false;

    private void Start()
    {
        currentHealth = maxHealth;
        thisSprite = Resources.Load<Sprite>(PlayerPrefs.GetString("SpriteLocation", "PlaceHolderCharacter"));
        gameObject.GetComponent<SpriteRenderer>().sprite = thisSprite;
        Destroy(gameObject.GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }

    public void MoveRight()
    {
        if (transform.position.x == 0)
        {
            targetPosition = new Vector2(transform.position.x + moveIncrement, transform.position.y);
        }
        if (transform.position.x == maxCharacterCanGoRight)
        {
            //Do nothing basically
        }
        if (transform.position.x == minCharacterCanGoLeft)
        {
            targetPosition = new Vector2(transform.position.x + moveIncrement, transform.position.y);
        }

        if(AudioManager.instance == null){
            return;
        }

        //Makes the PlayerMoved sound!
        AudioManager.instance.Play("PlayerMoved");
    }

    public void MoveLeft()
    {
        if (transform.position.x == 0)
        {
            targetPosition = new Vector2(transform.position.x - moveIncrement, transform.position.y);
        }
        if (transform.position.x == minCharacterCanGoLeft)
        {
            //Do nothing basically
        }
        if(transform.position.x == maxCharacterCanGoRight)
        {
            targetPosition = new Vector2(transform.position.x - moveIncrement, transform.position.y);
        }

        if(AudioManager.instance == null){
            return;
        }
        //Makes the PlayerMoved sound!
        AudioManager.instance.Play("PlayerMoved");
    }

    // Update is called once per frame
    void Update()
    {

        if (health == 0 && isActivated1 == false)
        {
            Time.timeScale = 0f;
            deathCanvas.SetActive(true);
            isActivated1 = true;
        }

        if (health == 0){
            Time.timeScale = 0f;
        }


        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        //Important code allows us to use the cursor's point on screen as a vector
        Vector3 mouse = new Vector3(Input.mousePosition.x, transform.position.y, zAxisPosition - Camera.main.transform.position.z);
        mouse = Camera.main.ScreenToWorldPoint(mouse);


        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }

         if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }           


    }

    public void ChangeHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}
