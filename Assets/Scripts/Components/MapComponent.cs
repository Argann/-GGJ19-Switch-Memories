using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MapComponent : MonoBehaviour
{

    bool isMapShown = false;

    RectTransform rectTransform;
    
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(
            0,
            -Screen.height
        );
    }

    void OnEnable()
    {
        GameEventManager.OnPictureDiscovered.AddListener(OnPictureDiscovered);
        GameEventManager.OnCharacterChange.AddListener(OnCharacterChange);
    }

    void OnDisable()
    {
        GameEventManager.OnPictureDiscovered.RemoveListener(OnPictureDiscovered);
        GameEventManager.OnCharacterChange.RemoveListener(OnCharacterChange);
    }

    void OnPictureDiscovered (GameEventPayload _)
    {
        ToggleMap();
    }

    void OnCharacterChange(GameEventPayload _)
    {
        ToggleMap();
    }

    public void ToggleMap()
    {
        isMapShown = !isMapShown;

        if (isMapShown)
        {
            rectTransform.DOAnchorPosY(0, 0.7f).SetEase(Ease.OutCubic);
        }
        else
        {
            rectTransform.DOAnchorPosY(-Screen.height, 0.7f).SetEase(Ease.OutCubic);
        }
    }
}
