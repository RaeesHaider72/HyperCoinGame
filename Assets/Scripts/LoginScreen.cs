using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginScreen : MonoBehaviour
{
    public Button closeBtn;

    public Button forgetEmail;
    public Button forgetPassword;



    private void Start()
    {
        AddListenerToBtns();
    }

    private void AddListenerToBtns()
    {
        closeBtn.onClick.AddListener(() => CloseBtnReference());
        forgetEmail.onClick.AddListener(() => ForgetEmailReference());
        forgetPassword.onClick.AddListener(() => ForgetEmailReference());
    }

    private void ForgetEmailReference()
    {
        Application.OpenURL("https://www.google.com/");
    }

    private void CloseBtnReference()
    {
        SoundManager.instance.soundAudio.Play();
        gameObject.SetActive(false);
        MainMenuController.instance.mainMenuScreen.SetActive(true);

    }
}
