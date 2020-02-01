using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable Object représentant une photo au sein du dossier de jeu.
/// </summary>
[CreateAssetMenu(menuName = "Switch Memory/New Picture")]
public class Picture : ScriptableObject
{
    /// <summary>
    /// Enumération des différents états possibles d'une image
    /// </summary>
    public enum PictureState
    {
        Unknown,
        ToDiscover,
        Discovered
    }

    /// <summary>
    /// Nom affiché sous la photo
    /// </summary>
    public string displayName;

    /// <summary>
    /// Sprite de la photo
    /// </summary>
    public Sprite mainSprite;

    /// <summary>
    /// Etat actuel de la photo.
    /// </summary>
    public PictureState state;
}
