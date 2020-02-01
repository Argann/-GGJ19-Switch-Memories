using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    Dictionary<string, List<string>> notes;

    public GameObject contentSpawner;

    public GameObject notePrefab;

    void OnEnable()
    {
        GameEventManager.OnCharacterChange.AddListener(OnCharacterChange);
        GameEventManager.OnUnlockAction.AddListener(AddNote);
    }

    void OnDisable()
    {
        GameEventManager.OnCharacterChange.RemoveListener(OnCharacterChange);
        GameEventManager.OnUnlockAction.RemoveListener(AddNote);
    }

    void Start()
    {
        notes = new Dictionary<string, List<string>>();

        foreach (Character character in DatabaseManager.instance.characters)
        {
            notes.Add(character.displayName, new List<string>());
        }
    }

    void OnCharacterChange(GameEventPayload _)
    {
        foreach (Transform transform in contentSpawner.transform)
        {
            Destroy(transform.gameObject);
        }

        Character character = _.Get<Character>("Character");

        foreach (string item in notes[character.displayName])
        {
            notePrefab.GetComponent<TMPro.TextMeshProUGUI>().text = item;
            GameObject.Instantiate(notePrefab, Vector3.zero, Quaternion.identity, contentSpawner.transform);
        }
    }

    void AddNote(GameEventPayload _)
    {
        UnlockAction action = _.Get<UnlockAction>("Action");

        notes[action.targetCharacter.displayName].Add(action.noteToJournal);

        notePrefab.GetComponent<TMPro.TextMeshProUGUI>().text = action.noteToJournal;
        GameObject.Instantiate(notePrefab, Vector3.zero, Quaternion.identity, contentSpawner.transform);
    }
}
