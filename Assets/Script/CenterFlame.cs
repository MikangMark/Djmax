using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFlame : MonoBehaviour
{
    AudioSource myAudio;
    bool musicStart = false;
    private void Start()
    {
        myAudio = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!musicStart)
        {
            if (collision.CompareTag("Note"))
            {
                if (!SoundManager.Instance.play)
                {
                    myAudio.Play();
                    musicStart = true;
                    SoundManager.Instance.play = true;
                }
                
            }
        }
        
    }
}
