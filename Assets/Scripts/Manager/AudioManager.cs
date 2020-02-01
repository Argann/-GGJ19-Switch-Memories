using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public struct Sound
    {
        public string name;

        public AudioClip clip;

    }

    public List<Sound> sounds;

    public AudioSource music;

    public AudioSource fx;

    public static AudioManager instance;

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

    public static void PlayMusic(string name)
    {
        instance.music.Stop();

        instance.music.clip = instance.sounds.Find(_ => _.name == name).clip;

        instance.music.Play();
    }

    public static void PlayFX(string name)
    {
        instance.fx.PlayOneShot(instance.sounds.Find(_ => _.name == name).clip);
    }
}
