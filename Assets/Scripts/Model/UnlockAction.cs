using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Modèle définissant une action de débloquage de photo
/// </summary>
[CreateAssetMenu(menuName = "Switch Memory/New Unlock Action")]
public class UnlockAction : ScriptableObject
{
    /// <summary>
    /// Quelle photo lance l'action de débloquage ?
    /// </summary>
    public Picture targetPicture;

    /// <summary>
    /// Quelle personnage lance l'action de débloquage ?
    /// </summary>
    public Character targetCharacter;

    /// <summary>
    /// Qu'est ce qui est débloqué par l'action ?
    /// </summary>
    public List<Picture> unlockedPictures;

    /// <summary>
    /// Que doit-on écrire dans les notes du journal ?
    /// </summary>
    public string noteToJournal;

    /// <summary>
    /// Est ce que l'action à déjà été effectuée ?
    /// </summary>
    public bool isUnlocked = false;
}
