using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject settings;

    public AudioSource audioSource;

    public void Play()
    {
        print("Play");
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings()
    { 
        settings.SetActive(true);
        gameObject.SetActive(false);
        audioSource.Play();
    }

    public void Exit()
    {
        audioSource.Play();
        print("Exit");
        Application.Quit();
    }
}
