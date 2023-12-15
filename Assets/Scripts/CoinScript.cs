using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public TextMeshProUGUI moneyBox;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("CoinCount", 0);
        //Debug.Log(PlayerPrefs.GetInt("CoinCount")); Became annoying
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PlaceHolderCharacter")
        {
            PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + 1);
            Destroy(gameObject);
            AudioManager.instance.Play("CoinSound");
            //Debug.Log(PlayerPrefs.GetInt("CoinCount"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(moneyBox == null)
        {
            return;
        }

        moneyBox.text = PlayerPrefs.GetInt("CoinCount").ToString();
    }
}
