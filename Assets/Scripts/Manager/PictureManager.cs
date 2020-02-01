using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PictureManager : MonoBehaviour
{
    public GameObject picturePrefab;

    public float minRotation;

    public float maxRotation;

    public Vector2 minSpawnZonePos;

    public Vector2 maxSpawnZonePos;

    public Transform spawnParent;

    private static PictureManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        List<Picture> filteredList = DatabaseManager.instance.pictures
            .Where(_ => _.state == Picture.PictureState.Discovered)
            .ToList();

        foreach (Picture picture in filteredList)
        {
            Spawn(picture);
        }
    }

    void OnEnable()
    {
        GameEventManager.OnUnlockAction.AddListener(OnUnlockActionEvent);
        GameEventManager.OnPictureDiscovered.AddListener(OnPictureDiscovered);
    }

    void OnDisable()
    {
        GameEventManager.OnUnlockAction.RemoveListener(OnUnlockActionEvent);
        GameEventManager.OnPictureDiscovered.RemoveListener(OnPictureDiscovered);
    }
    
    void OnUnlockActionEvent(GameEventPayload payload)
    {
        foreach (Picture picture in payload.Get<UnlockAction>("Action").unlockedPictures)
        {
            picture.state = Picture.PictureState.ToDiscover;

            GameEventManager.OnPictureToDiscover.Invoke(new Dictionary<string, object>(){
                ["Picture"] = picture
            });
        }
    }

    void OnPictureDiscovered(GameEventPayload _)
    {
        Picture p = _.Get<Picture>("Picture");

        Spawn(p);
    }


    void Spawn(Picture picture)
    {
        Vector3 rPos = new Vector3(
            Random.Range(minSpawnZonePos.x, maxSpawnZonePos.x),
            Random.Range(minSpawnZonePos.y, maxSpawnZonePos.y),
            0
        );

        picturePrefab.GetComponent<PictureComponent>().picture = picture;

        picturePrefab.transform.Find("Sprite").GetComponent<SpriteRenderer>().color =
            new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );
        
        GameObject go = GameObject.Instantiate(
            picturePrefab, 
            rPos, 
            Quaternion.Euler(0, 0, Random.Range(minRotation, maxRotation)),
            spawnParent
            );
    }
}
