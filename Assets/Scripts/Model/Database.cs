using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Switch Memory/New Database")]
public class Database : ScriptableObject
{
    /// <summary>
    /// Liste de toutes les photos du jeu
    /// </summary>
    public List<Picture> pictures;

    /// <summary>
    /// Liste de tous les personnages du jeu
    /// </summary>
    public List<Character> characters;

    /// <summary>
    /// Liste de toutes les actions de débloquage du jeu
    /// </summary>
    public List<UnlockAction> unlockActions;
}
