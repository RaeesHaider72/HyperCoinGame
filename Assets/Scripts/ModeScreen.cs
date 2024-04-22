using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModeScreen : MonoBehaviour
{
    public Button closeBtn;
    public Button singlePlayerBtn;
    public Button multiplayerBtn;


    private void Start()
    {
        AddListenerToBtns();
    }

    private void AddListenerToBtns()
    {
        closeBtn.onClick.AddListener(() => CloseBtnReference());
        singlePlayerBtn.onClick.AddListener(() => SinglePlayerReference());
    }

    private void SinglePlayerReference()
    {
        SoundManager.instance.soundAudio.Play();
        SceneManager.LoadScene("SinglePlayer");
    }

    private void CloseBtnReference()
    {
        SoundManager.instance.soundAudio.Play();
        gameObject.SetActive(false);
        GameMenu.instance.mainMenuScreen.SetActive(true);
    }
}
