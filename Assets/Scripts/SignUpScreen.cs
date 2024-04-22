using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignUpScreen : MonoBehaviour
{

    public Button closeBtn;
    
    private void Start()
    {
        AddListenerToBtns();
    }

    private void AddListenerToBtns()
    {
        closeBtn.onClick.AddListener(() => CloseBtnReference());
        
    }

    private void CloseBtnReference()
    {
        SoundManager.instance.soundAudio.Play();
        gameObject.SetActive(false);
        MainMenuController.instance.mainMenuScreen.SetActive(true);

    }


}
