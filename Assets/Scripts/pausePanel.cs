using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pausePanel : MonoBehaviour
{

    public Button homeBtn;
    public Button resumeBtn;
    public Button restartBtn;


    private void Start()
    {
        AddListenerToBtns();
    }

    private void AddListenerToBtns()
    {
        homeBtn.onClick.AddListener(() => HomeBtnReference());
        resumeBtn.onClick.AddListener(() => ResumeBtnReference());
        restartBtn.onClick.AddListener(() => RestartBtnReference());
    }

    private void RestartBtnReference()
    {
        SoundManager.instance.soundAudio.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ResumeBtnReference()
    {
        SoundManager.instance.soundAudio.Play();
        Time.timeScale = 1;
        GMSinglePlayer.instance.gamePlayCharacter.SetActive(true);
        this.gameObject.SetActive(false);

    }

    private void HomeBtnReference()
    {
        SoundManager.instance.soundAudio.Play();
        SceneManager.LoadScene("StartMenu");
    }
}
