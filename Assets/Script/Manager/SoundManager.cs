using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{

    public bool play;
    private void Start()
    {
        play = false;
    }
    
}
