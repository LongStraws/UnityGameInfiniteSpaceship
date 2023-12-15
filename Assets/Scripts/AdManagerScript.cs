    using System;
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using TMPro;

public class AdManagerScript : MonoBehaviour, IUnityAdsShowListener, IUnityAdsLoadListener, IUnityAdsInitializationListener
{
    #if UNITY_ANDROID
    private string theGameID = "3761311";
    #elif UNITY_IOS
    private string theGameID = "3761310";
    #endif

     //Don't forget to change gamemode before shipping to false;
    readonly bool GameMode = false;
    public Button gameButton;
    public PlayerController playerController;
    public GameObject deathPanel;
    bool adShown = false;
    public bool adGivesCoins;

    //Floats for the cooldown of the button
    [SerializeField]
    private float coolDown;
    private float currentTime = 300000;

    //Floats and variables for countdown timer
    private float timeCurrent;
    private float startingTime = 3f;
    private bool countDownStarted;
    private bool countDownEnded = false;
    private bool lifeGained = false;
    private bool isActivated = false;
    public GameObject countDownPanel;
    public Vector4 blackTransparent = new Vector4(1f,.8f,1f, 0f);
    public Vector4 justBlack = new Vector4(1f,1f,1f, 1f);
    public TextMeshProUGUI countDownText ;


    private void Awake() {
        Advertisement.Initialize(theGameID, GameMode, this);
    }

    // Start is called before the first frame update
    private void Start()
    {
        timeCurrent = startingTime;
    }
 
    private void Update()
    {
        if (!(currentTime < coolDown))
        {
            if (currentTime >= coolDown)
            {
                currentTime = coolDown;

                if (gameButton == null)
                {
                    return;
                }

                gameButton.interactable = true;
            }
        }
        else
        {
            currentTime += Time.deltaTime;
        }

        if (countDownStarted == true && timeCurrent >= 0)
        {
            deathPanel.SetActive(false);
            countDownPanel.SetActive(true);
            timeCurrent -= + Time.unscaledDeltaTime;
            countDownText.text = timeCurrent.ToString("0");
    
        }

        if(timeCurrent <= 0 && lifeGained == false){
            countDownEnded = true;
            playerController.ChangeHealth(1);
            playerController.isActivated1 = false; 
            countDownPanel.SetActive(false);
            gameButton.interactable = false;
            lifeGained = true;  
        }     

        if (lifeGained == true){

            gameButton.interactable = false;
        }   

        if (countDownEnded == true && isActivated == false)
        {
            countDownPanel.SetActive(false);
            countDownEnded = false;
            isActivated = true;
        }

        if (playerController.health >= 1){
            countDownPanel.SetActive(false);
        }

    }

    public void ShowAd(string adName)
    {
        if (Math.Abs(currentTime - coolDown) < .001 && Advertisement.IsReady(adName) && adShown == false)
        {
            Advertisement.Load(adName, this);
            Advertisement.Show(adName, null,this);
            currentTime = 0;
            Time.timeScale = 0f;
            gameButton.interactable = false;
        } 
    }
    
    public void OnUnityAdsShowClick(string adName)
    {
        
         
    }
    
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showResult)
    {
        switch (showResult)
        {
            case UnityAdsShowCompletionState.COMPLETED when adGivesCoins == true:
                PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + 5);
                //Advertisement.RemoveListener(this);
                break;
            case UnityAdsShowCompletionState.SKIPPED:
                //Advertisement.RemoveListener(this);
                break;
        }

        if(showResult == UnityAdsShowCompletionState.COMPLETED)
        {
            
            adShown = true;
            if(deathPanel != null)
            {
                countDownStarted = true;
            }
            
        }else{
            return;
        }
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        return;
    }

    public void OnUnitAdsFailedToLoad(string adName, UnityAdsLoadError error, string message)
    {
        return;
    }

    
    public void OnUnityAdsReady(string placementId)
    {
        return;
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        return;
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        return;
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)    
    {
        return;
    }

    public void OnInitializationComplete()
    {
        return;
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        return;
    }
}
