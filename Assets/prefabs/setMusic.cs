    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMusic : MonoBehaviour
{
    public AudioSource mainMusic;
    public AudioSource UiSound;

    private float musicVolume = 1f;
    private float UiVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        mainMusic.Play();
        UiSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        mainMusic.volume = musicVolume;
        UiSound.volume = UiVolume;

    }
    public void updateMolume(float mVolume)
    {
        musicVolume = mVolume;
    }
    public void updateSolume(float uVolume)
    {
        UiVolume = uVolume;
    }
}
