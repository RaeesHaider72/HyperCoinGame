using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScreen : MonoBehaviour
{

    public Button sureBtn;
    public Button laterBtn;

    public GameObject character1;
    public GameObject character2;

    private Vector3 cha1Position;
    private Vector3 cha2Position;


    private void Awake()
    {
        cha1Position = character1.transform.position;
        cha2Position = character2.transform.position;
    }


    private void OnEnable()
    {

        character1.transform.position = cha1Position;
        character2.transform.position = cha2Position;
    }
    private void Start()
    {
        character1.transform.position = cha1Position;
        character2.transform.position = cha2Position;


        AddListenerToBtns();
    }

    private void AddListenerToBtns()
    {
        laterBtn.onClick.AddListener(() => CloseBtnReference());
        sureBtn.onClick.AddListener(() => CloseApplicationReference());

    }

    private void CloseApplicationReference()
    {
        Application.Quit();
    }

    private void CloseBtnReference()
    {
        SoundManager.instance.soundAudio.Play();
        gameObject.SetActive(false);
        MainMenuController.instance.mainMenuScreen.SetActive(true);

    }
}
