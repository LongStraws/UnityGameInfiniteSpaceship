using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class CharacterSelection : MonoBehaviour
{
    private int selectedCharacterIndex;
    public int selectedCharacterIndexForOtherScripts;
    public string selectedSpriteOfCharacterString;
    public Sprite selectedCharacterSprite;
    public string stateOfCharacterForOtherScripts;
    private Color desiredColor;
    public Sprite lockLockedStateSprite;
    public Sprite lockUnlockedStateSprite;



    [Header("List of characters")]
    [SerializeField] private List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private Image characterSplash;
    [SerializeField] private Image backgroundColorOfSplash;
    [SerializeField] private TextMeshProUGUI costOfCharacter;

    [Header("Sounds")]
    [SerializeField] private AudioClip clickSFX;
    [SerializeField] private AudioClip characterSelectMusic;

    [Header("Variables")]
    [SerializeField] private float backgroundColorTransitionSpeed;
    

    private void Start()
    {
        UpdateCharacterSelectionUI();
        PlayerPrefs.GetString("Selected Character Sprite", "PlaceHolderCharacter");
    }

    private void Update()
    {
        backgroundColorOfSplash.color = Color.Lerp(backgroundColorOfSplash.color, characterList[selectedCharacterIndex].characterColor, Time.deltaTime * backgroundColorTransitionSpeed);
        selectedSpriteOfCharacterString = characterList[selectedCharacterIndex].splash.name;

        stateOfCharacterForOtherScripts = characterList[selectedCharacterIndex].stateOfCharacter;

        selectedCharacterSprite = characterList[selectedCharacterIndex].splash;

        //Debug.Log(selectedSpriteOfCharacter);
        //Debug.Log(PlayerPrefs.GetString("Selected Character Sprite"));
        //Debug.Log(selectedCharacterIndex);
    }

    public void LeftArrow()
    {
        selectedCharacterIndex--;
        if(selectedCharacterIndex < 0)
        {
            selectedCharacterIndex = characterList.Count - 1;
        }

        UpdateCharacterSelectionUI();
    }


    public void RightArrow()
    {
        selectedCharacterIndex++;
        if (selectedCharacterIndex == characterList.Count)
        {
            selectedCharacterIndex = 0;
        }

        UpdateCharacterSelectionUI();
    }

    private void UpdateCharacterSelectionUI()
    {
        //Changes the character's sprite 
        characterSplash.sprite = characterList[selectedCharacterIndex].splash;

        //Changes the text to the characters name
        characterName.text = characterList[selectedCharacterIndex].characterName;

        //Changes the bg to the desired color
        desiredColor = characterList[selectedCharacterIndex].characterColor;

        //Changes the cost text to characters cost
        costOfCharacter.text = characterList[selectedCharacterIndex].costOfCharacter.ToString("0");

        //Changes the PlayerPref string that corresponds to the character sprite
        PlayerPrefs.SetString("Selected Character Sprite", characterList[selectedCharacterIndex].splash.name);

        //Changes the state of character in the public class to the playerPref one?
        characterList[selectedCharacterIndex].stateOfCharacter = PlayerPrefs.GetString(characterList[selectedCharacterIndex].splash.name, characterList[selectedCharacterIndex].stateOfCharacter);

        //So other scripts can see the state of the character, but not actually have access!!
        stateOfCharacterForOtherScripts = characterList[selectedCharacterIndex].stateOfCharacter;

        if (characterList[selectedCharacterIndex].stateOfCharacter == "Locked")
        {
            characterList[selectedCharacterIndex].characterState.sprite = lockLockedStateSprite;
        }
        else if (characterList[selectedCharacterIndex].stateOfCharacter == "Unlocked")
        {
            characterList[selectedCharacterIndex].characterState.sprite = lockUnlockedStateSprite;
        }

        selectedCharacterSprite = characterList[selectedCharacterIndex].splash;
        //Debug.Log(characterList[selectedCharacterIndex].stateOfCharacter);

        //Debug.Log("The PlayerPref " + characterList[selectedCharacterIndex].splash.name + " is in the state of " + PlayerPrefs.GetString(characterList[selectedCharacterIndex].splash.name, "Locked"));
    }

    //This changes the stateOfCharacter in the public class CharacterSelectObject to unlocked if the buy button is pressed
    public void ChangeStateOfCharacter()
    {

        characterList[selectedCharacterIndex].stateOfCharacter = PlayerPrefs.GetString(characterList[selectedCharacterIndex].splash.name, characterList[selectedCharacterIndex].stateOfCharacter);

        Debug.Log(characterList[selectedCharacterIndex].splash.name + " " + characterList[selectedCharacterIndex].stateOfCharacter);

        //Changes the playerpref of the selected/ bought character to unlocked
        PlayerPrefs.SetString(characterList[selectedCharacterIndex].splash.name, "Unlocked");

        UpdateCharacterSelectionUI();
    }

    [System.Serializable]
    public class CharacterSelectObject
    {
        public Sprite splash;
        public string characterName;
        public Color characterColor;
        public int costOfCharacter;
        public string stateOfCharacter;
        public Image characterState;
    }
}
