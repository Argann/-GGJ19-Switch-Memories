using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public TextMeshProUGUI characterName;

    public CharacterReleaseZone releaseZone;

    public Character currentCharacter;

    public static CharacterManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        currentCharacter = DatabaseManager.instance.characters.Find(_ => _.displayName == currentCharacter.displayName);

        characterName.text = currentCharacter.displayName;

        releaseZone.character = currentCharacter;
    }

    public void ChangeCharacter(Character character)
    {
        currentCharacter = character;

        characterName.text = currentCharacter.displayName;

        releaseZone.character = currentCharacter;

        GameEventManager.OnCharacterChange.Invoke(new Dictionary<string, object>(){
            ["Character"] = currentCharacter
        });
    }
}
