using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Range(0, 2.0f)]
    public float SFX_Volume = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.time *= Time.unscaledDeltaTime;
        audioSource.clip = clip;
        audioSource.Play();
        audioSource.volume *= SFX_Volume;

        Destroy(go, clip.length);
    }
}
