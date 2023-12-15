using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EquipingSpriteScript : MonoBehaviour
{
    public CharacterSelection charSelection;
    PlayerController playerController;
    SpriteRenderer spriteRendererOfCharacter;
    public GameObject playerPrefab;

    public void EquipSprite()
    {
        if (charSelection.stateOfCharacterForOtherScripts == "Unlocked")
        {
            //spriteRendererOfCharacter.sprite = charSelection.selectedCharacterSprite;
            PlayerPrefs.SetString("SpriteLocation", charSelection.selectedSpriteOfCharacterString);

            Debug.Log(PlayerPrefs.GetString("SpriteLocation"));
        }

       
    }
}
