using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{

    public Character character;

    public void SwitchCharacter()
    {
        Character c = DatabaseManager.instance.characters.Find(_ => _.displayName == character.displayName);

        CharacterManager.instance.ChangeCharacter(c);
    }
}
