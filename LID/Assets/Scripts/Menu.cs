using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject settings;

    public void Play()
    {
        print("Play");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings()
    { 
        settings.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Exit()
    {
        print("Exit");
        Application.Quit();
    }
}
