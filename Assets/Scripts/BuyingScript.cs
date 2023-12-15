using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyingScript : MonoBehaviour
{
    private int costOfCharacter;
    private string money;
    public TextMeshProUGUI moneyAmount;
    public CharacterSelection charSelection;

    // Update is called once per frame
    void Update()
    {
        money = moneyAmount.text;
        costOfCharacter = int.Parse(money);
    }

    public void Buy()
    {
        if(PlayerPrefs.GetInt("CoinCount", 0) >= costOfCharacter && charSelection.stateOfCharacterForOtherScripts == "Locked" )
        {
            PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") - costOfCharacter);
            charSelection.ChangeStateOfCharacter();
        }
        else
        {
            return;
        }

        //Debug.Log(costOfCharacter);
    }
}
