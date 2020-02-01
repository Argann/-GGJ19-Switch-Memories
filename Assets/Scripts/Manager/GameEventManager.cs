using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager permettant de lister tous les évènements de jeu
/// </summary>
public static class GameEventManager
{
    /// <summary>
    /// Evenement appelé lorsqu'un drag à commencé.
    /// 
    /// "Behaviour" -> DraggableBehaviour
    /// </summary>
    public static GameEvent OnDragBegin = new GameEvent("OnBeginDrag");

    /// <summary>
    /// Evenement appelé lorsqu'un drag à terminé.
    /// 
    /// "Behaviour" -> DraggableBehaviour
    /// </summary>
    public static GameEvent OnDragEnd = new GameEvent("OnDragEnd");

    /// <summary>
    /// Evenement appelé lorsqu'une action de débloquage est lancée
    /// 
    /// "Action" -> UnlockAction
    /// </summary>
    public static GameEvent OnUnlockAction = new GameEvent("OnUnlockAction");

    /// <summary>
    /// Evenement appelé lorsqu'une photo passe à l'état 'to discover'
    /// 
    /// "Picture" -> Picture
    /// </summary>
    public static GameEvent OnPictureToDiscover = new GameEvent("OnPictureToDiscover");

    /// <summary>
    /// Evenement appelé lorsqu'une photo passe à l'état 'discovered'
    /// 
    /// "Picture" -> Picture
    /// </summary>
    public static GameEvent OnPictureDiscovered = new GameEvent("OnPictureDiscovered");

    /// <summary>
    /// Evenement appelé lorsqu'on change de personnage
    /// 
    /// "Character" -> Character
    /// </summary>
    /// <returns></returns>
    public static GameEvent OnCharacterChange = new GameEvent("OnCharacterChange");
}
