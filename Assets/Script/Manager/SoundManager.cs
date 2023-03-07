using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public bool play;
    public AudioSource[] audioSources;
    public float play_volue;
    private void Start()
    {
        if (play_volue == 0f)
        {
            play_volue = 0.5f;
        }
        for(int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].volume = PlayerPrefs.GetFloat("volum");
        }
        play = false;

    }
    
}
