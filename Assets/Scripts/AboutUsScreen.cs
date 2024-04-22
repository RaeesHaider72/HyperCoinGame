using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutUsScreen : MonoBehaviour
{
    public Button sureBtn;

    public GameObject character1;

    private Vector3 cha1Position;


    private void Awake()
    {
        cha1Position = character1.transform.position;
    }


    private void OnEnable()
    {

        character1.transform.position = cha1Position;
    }
    private void Start()
    {
        character1.transform.position = cha1Position;


        AddListenerToBtns();
    }

    private void AddListenerToBtns()
    {
        sureBtn.onClick.AddListener(() => CloseBtnReference());

    }

    private void CloseBtnReference()
    {
        SoundManager.instance.soundAudio.Play();
        gameObject.SetActive(false);
        GameMenu.instance.mainMenuScreen.SetActive(true);

    }
}
