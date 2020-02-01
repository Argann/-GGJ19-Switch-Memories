using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PictureSpawnAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 baseScale = transform.localScale;

        transform.localScale *= 2;
        
        spriteRenderer.color = new Color(
            spriteRenderer.color.r,
            spriteRenderer.color.g,
            spriteRenderer.color.b,
            0
        );

        transform.DOScale(baseScale, 0.6f).SetEase(Ease.InQuint);

        spriteRenderer.DOFade(1f, 0.6f).SetEase(Ease.InQuint);
    }

}
