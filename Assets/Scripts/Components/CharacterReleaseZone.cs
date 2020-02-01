using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterReleaseZone : MonoBehaviour
{
    public Character character;

    private Picture hoveredPicture;

    void OnEnable()
    {
        GameEventManager.OnDragEnd.AddListener(OnAnyDragEnded);
    }

    void OnDisable()
    {
        GameEventManager.OnDragEnd.RemoveListener(OnAnyDragEnded);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Picture"))
        {
            hoveredPicture = coll.transform.parent.GetComponent<PictureComponent>().picture;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Picture"))
        {
            hoveredPicture = null;
        }
    }

    void OnAnyDragEnded(GameEventPayload _)
    {
        if (hoveredPicture != null)
        {
            UnlockActionManager.TryUnlock(character, hoveredPicture);
        }
    }
}
