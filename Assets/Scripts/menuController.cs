using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);

    }

    public void Exitapp()
    {
        Application.Quit();
    }

    public void privacyInfo()
    {
        Application.OpenURL("");
    }
    public void more()
    {
        Application.OpenURL("");
    }
    public void pauseButton()
    {

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }
}
