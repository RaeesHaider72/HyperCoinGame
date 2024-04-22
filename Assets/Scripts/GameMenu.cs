using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public static GameMenu instance;
    [Header("GameObjects")]
    public GameObject mainMenuScreen;
    public GameObject modeSelection;
    public GameObject leaderBoardPanel;
    public GameObject settingPanel;
    public GameObject aboutUsPanel;


    [Header("Buttons")]
    public Button startGameBtn;
    public Button leaderBoardBtn;
    public Button settingBtn;
    public Button aboutUsBtn;
    public Button BackBtn;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        Time.timeScale = 1;
        AddListenerToBtns();
    }

    private void AddListenerToBtns()
    {
        startGameBtn.onClick.AddListener(() => StartGameReference());
        leaderBoardBtn.onClick.AddListener(() => leaderBoardReference());
        settingBtn.onClick.AddListener(() => SettingBtnReference());
        aboutUsBtn.onClick.AddListener(() => AboutUsBtnReference());
        BackBtn.onClick.AddListener(() => GoBackPanel());
    }

    private void AboutUsBtnReference()
    {
        SoundManager.instance.soundAudio.Play();

        aboutUsPanel.SetActive(true);
        mainMenuScreen.SetActive(false);
    }

    private void SettingBtnReference()
    {
        SoundManager.instance.soundAudio.Play();
        settingPanel.SetActive(true);
        mainMenuScreen.SetActive(false);
    }

    private void leaderBoardReference()
    {
        SoundManager.instance.soundAudio.Play();
        SceneManager.LoadScene("LeaderBoard");
       
    }

    private void StartGameReference()
    {
        SoundManager.instance.soundAudio.Play();
        mainMenuScreen.SetActive(false);
        modeSelection.SetActive(true);
    }

    private void GoBackPanel()
    {
        //SoundManager.instance.soundAudio.Play();
        SceneManager.LoadScene("MainMenu");
    }


}
