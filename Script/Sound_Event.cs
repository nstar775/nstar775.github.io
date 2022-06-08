using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Event : MonoBehaviour
{
    public AudioClip clip;
    public string AudioMassege = "";

    private void Start()
    {
        AudioManager.instance.SFXPlay(AudioMassege, clip);
    }

}
