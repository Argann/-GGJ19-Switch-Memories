using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnlockActionManager
{
    public static void TryUnlock(Character character, Picture picture)
    {
        UnlockAction action = DatabaseManager.instance.unlockActions.Find(_ => 
            _.targetCharacter.displayName == character.displayName
            && _.targetPicture.displayName == picture.displayName
            && _.isUnlocked == false);
        
        if (action == null)
            return;

        action.isUnlocked = true;

        GameEventManager.OnUnlockAction.Invoke(new Dictionary<string, object>(){
            ["Action"] = action
        });

    }
}
