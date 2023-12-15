using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI highScore;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetFloat("HiScore", 0).ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        float timeSinceLevelLoad = Time.timeSinceLevelLoad;

        scoreText.text = timeSinceLevelLoad.ToString("0");

        if(timeSinceLevelLoad > PlayerPrefs.GetFloat("HiScore", 0) && SceneManager.GetActiveScene().name == "GameScene")
        {
            PlayerPrefs.SetFloat("HiScore", timeSinceLevelLoad);

            highScore.text = timeSinceLevelLoad.ToString("0");
        }
    }

    public void ResetHiScore()
    {
        PlayerPrefs.DeleteKey("HiScore");

        highScore.text = "0";
    }

}
