using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject settings;
    public GameObject pause;

    public AudioSource audioSource;

    public void Play()
    {
        print("Play");

        audioSource.Play();
        Time.timeScale = 1f;
        pause.SetActive(false);
    }

    public void Settings()
    {

        audioSource.Play();
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
