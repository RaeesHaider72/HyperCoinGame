using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource soundAudio;
    public AudioSource musicAudio;



    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    
}
