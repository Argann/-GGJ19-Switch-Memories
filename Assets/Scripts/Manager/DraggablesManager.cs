using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DraggablesManager
{
    private static List<DraggableBehaviour> behaviours = new List<DraggableBehaviour>();

    public static void RegisterBehaviour(DraggableBehaviour b)
    {
        behaviours.Add(b);
    }

    static DraggablesManager()
    {
        GameEventManager.OnDragBegin.AddListener(OnAnyDragBegin);
    }

    static void OnAnyDragBegin(GameEventPayload payload)
    {
        if (behaviours.Count <= 1)
            return;

        DraggableBehaviour behaviour = payload.Get<DraggableBehaviour>("Behaviour");

        int i = behaviours.IndexOf(behaviour);

        behaviours.Move(i, 0);
        
        for (int j = 0; j < behaviours.Count; j++)
        {
            DraggableBehaviour b = behaviours[j];

            b.targetTransform.position = new Vector3(
                b.targetTransform.position.x,
                b.targetTransform.position.y,
                (1f - ((float)j / ((float)behaviours.Count - 1f))) * -1f
            );
        }
    }
}
