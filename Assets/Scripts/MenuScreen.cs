
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    [Header("GameObecjts")]
    public GameObject signUpPanel;
    public GameObject loginPanel;
    public GameObject exitPanel;
    public GameObject settingPanel;


    [Header("Buttons")]
    public Button playBtn;
    public Button signUpBtn;
    public Button loginBtn;
    public Button settingBtn;
    public Button exitBtn;




    private void Start()
    {
        AddListenerToBtns();
    }

    private void AddListenerToBtns()
    {
        playBtn.onClick.AddListener(() => PlayBtnReference());
        signUpBtn.onClick.AddListener(() => SignBtnReference());
        loginBtn.onClick.AddListener(() => LoginBtnReference());
        settingBtn.onClick.AddListener(() => SettinPanelReference());
        exitBtn.onClick.AddListener(() => ExitBtnReference());
    }

    private void ExitBtnReference()
    {
        SoundManager.instance.soundAudio.Play();
        exitPanel.SetActive(true);
    }

    private void SettinPanelReference()
    {
        SoundManager.instance.soundAudio.Play();
        settingPanel.SetActive(true);
    }

    private void LoginBtnReference()
    {
        SoundManager.instance.soundAudio.Play();
        loginPanel.SetActive(true);
    }

    private void SignBtnReference()
    {
        SoundManager.instance.soundAudio.Play();
        signUpPanel.SetActive(true);
    }

    private void PlayBtnReference()
    {
        SoundManager.instance.soundAudio.Play();
        SceneManager.LoadScene("StartMenu");
    }




}
