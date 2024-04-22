using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingScreen : MonoBehaviour
{
  
    public Button closePanelBtn;

    public Slider musicSlider;
    public Slider soundSlider;


    public GameObject character1;
    public GameObject character2;

    private Vector3 cha1Position;
    private Quaternion cha1rotation;
    private Vector3 cha2Position;
    private Quaternion cha2rotation;

    public List<Button> qualitiesBtns = new List<Button>();

    private void Awake()
    {
        cha1Position = character1.transform.position;
        cha1rotation = character1.transform.rotation;
        cha2Position = character2.transform.position;
        cha2rotation = character2.transform.rotation;
    }


    private void OnEnable()
    {
       
        character1.transform.position = cha1Position;
        character1.transform.rotation = cha1rotation;
        character2.transform.position = cha2Position;
        character2.transform.rotation = cha2rotation;
    }


    private void Start()
    {
        character1.transform.position = cha1Position;
        character1.transform.rotation = cha1rotation;
        character2.transform.position = cha2Position;
        character2.transform.rotation = cha2rotation;


        AddListenerTobtns();
    }

    private void AddListenerTobtns()
    {

         closePanelBtn.onClick.AddListener(() => CloseBtnReference());

        musicSlider.onValueChanged.AddListener(OnMusicVolume);
        soundSlider.onValueChanged.AddListener(OnSoundVolume);

        OnMusicVolume(musicSlider.value);
        OnSoundVolume(soundSlider.value);

        qualitiesBtns[1].transform.GetChild(1).gameObject.SetActive(true);
        for (int i = 0; i < qualitiesBtns.Count; i++)
        {
            int index = i;
            qualitiesBtns[i].onClick.AddListener(() => OnQualityBtnClicked(index));
        }

    }

    void OnMusicVolume(float volume)
    {
        SoundManager.instance.musicAudio.volume = volume;
    }


    void OnSoundVolume(float volume)
    {
        SoundManager.instance.soundAudio.volume = volume;
    }



    private void CloseBtnReference()
    {
        SoundManager.instance.soundAudio.Play();
        gameObject.SetActive(false);
        if(MainMenuController.instance)
            MainMenuController.instance.mainMenuScreen.SetActive(true);
        else
            GameMenu.instance.mainMenuScreen.SetActive(true);
    }
    
    public void OnQualityBtnClicked(int index)
    {
        SoundManager.instance.soundAudio.Play();
        for (int i = 0; i < qualitiesBtns.Count; i++)
        {
            if(i == index)
            {
                qualitiesBtns[i].transform.GetChild(1).gameObject.SetActive(true);
               // qualitiesBtns[i].transform.GetChild(0).gameObject.SetActive(false);
                SetQuality(index);
            }
            else
            {
                qualitiesBtns[i].transform.GetChild(1).gameObject.SetActive(false);
                qualitiesBtns[i].transform.GetChild(0).gameObject.SetActive(true);
            }


        }
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
    

}
