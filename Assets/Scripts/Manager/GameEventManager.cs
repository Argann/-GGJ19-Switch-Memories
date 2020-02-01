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
}
