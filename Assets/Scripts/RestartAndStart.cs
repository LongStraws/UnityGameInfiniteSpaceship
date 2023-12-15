using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartAndStart : MonoBehaviour
{
    public Animator transition;
    float transitionTime = 1f;

    public void ForLoadScenes(int sceneindex)
    {
        //Because timescale is 0 when we pause from the menu and then restart
        //Time.timeScale = 1f;

        //Starts coroutine and loads level based on index of the button this script is attached to
        StartCoroutine(LoadLevel(sceneindex));
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(transitionTime);

        Time.timeScale = 1f;
        SceneManager.LoadScene(levelIndex);
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }

   
}
