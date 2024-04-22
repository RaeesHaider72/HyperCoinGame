using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController instance;

    [Header("GameObjects")]
    public GameObject loadingScreen;
    public GameObject mainMenuScreen;


    [Header("Images")]
    public Image fillBar;


    


    [Header("Variables")]
    public float maxTime;
    public float activeTime;
    private bool isAllow;



    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        QualitySettings.SetQualityLevel(1);
        loadingScreen.SetActive(true);
        mainMenuScreen.SetActive(false);
    }


    private void Update()
    {
        if (!isAllow)
        {
            activeTime += Time.deltaTime;
            float fillRatio = Mathf.Clamp01(activeTime / maxTime);
            fillBar.fillAmount = fillRatio;

            if (activeTime >= maxTime)
            {
                mainMenuScreen.SetActive(true);
                loadingScreen.SetActive(false);
                isAllow = true;
            }
        }
    }






}
