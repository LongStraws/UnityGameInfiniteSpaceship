using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameUICanvas;
    public static bool gameIsPaused = false;

    public void OnClickForPause()
    {
        pauseMenu.SetActive(true);
        gameUICanvas.SetActive(false);
    }

    public void OnClickForResume()
    {
        pauseMenu.SetActive(false);
        gameUICanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseMenu.activeSelf == false)
        {
            Time.timeScale = 1f;
        }

        if(pauseMenu.activeSelf == true)
        {
            Time.timeScale = 0f;
        }
    }
}
