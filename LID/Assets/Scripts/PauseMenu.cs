using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject settings;
    public GameObject pause;

    public void Play()
    {
        print("Play");
        Time.timeScale = 1f;
        pause.SetActive(false);
    }

    public void Settings()
    {
        settings.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Exit()
    {
        print("Exit");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
