using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource Music;
    public static float MusicVolume;

    void Start()
    {
        Music = GetComponent<AudioSource>();
        Music.volume = SceneManagerScript.AudioVolume;
        MusicVolume = SceneManagerScript.AudioVolume;
    }

}
