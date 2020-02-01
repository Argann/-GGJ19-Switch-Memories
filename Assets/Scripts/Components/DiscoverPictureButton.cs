using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscoverPictureButton : MonoBehaviour
{
    Button button;

    public Picture picture;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    void OnEnable()
    {
        GameEventManager.OnPictureToDiscover.AddListener(OnPictureUnlocked);
    }

    void OnDisable()
    {
        GameEventManager.OnPictureToDiscover.RemoveListener(OnPictureUnlocked);
    }

    void OnPictureUnlocked(GameEventPayload _)
    {
        Picture unlockedPicture = _.Get<Picture>("Picture");

        if (unlockedPicture.displayName == picture.displayName)
        {
            button.interactable = true;
        }
    }

    public void DestroyButton()
    {
        Picture unlockedPicture = DatabaseManager.instance.pictures.Find(_ => picture.displayName == _.displayName);

        unlockedPicture.state = Picture.PictureState.Discovered;

        GameEventManager.OnPictureDiscovered.Invoke(new Dictionary<string, object>(){
            ["Picture"] = unlockedPicture
        });
        
        Destroy(gameObject);
    }
}
