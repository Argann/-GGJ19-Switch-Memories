using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Manager unique de la base de donnée de jeu
/// </summary>
public class DatabaseManager : MonoBehaviour
{
    public Database asset;

    /// <summary>
    /// Liste de toutes les photos du jeu
    /// </summary>
    [System.NonSerialized]
    public List<Picture> pictures;

    /// <summary>
    /// Liste de tous les personnages du jeu
    /// </summary>
    [System.NonSerialized]
    public List<Character> characters;

    /// <summary>
    /// Liste de toutes les actions de débloquage du jeu
    /// </summary>
    [System.NonSerialized]
    public List<UnlockAction> unlockActions;

    public static DatabaseManager instance;

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

        pictures = asset.pictures.Select(_ => Instantiate(_)).ToList();
        characters = asset.characters.Select(_ => Instantiate(_)).ToList();
        unlockActions = asset.unlockActions.Select(_ => Instantiate(_)).ToList();
    }
    
}
