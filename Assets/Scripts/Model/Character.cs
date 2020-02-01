using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Modèle représentant les données d'un personnage de jeu.
/// </summary>
[CreateAssetMenu(menuName = "Switch Memory/New Character")]
public class Character : ScriptableObject
{
    /// <summary>
    /// Nom d'affichage du personnage
    /// </summary>
    public string displayName;

    /// <summary>
    /// Sprite principal représentant le personnage
    /// </summary>
    public Sprite mainSprite;
}
