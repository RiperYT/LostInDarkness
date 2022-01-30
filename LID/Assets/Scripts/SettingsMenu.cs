using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject menu;
    public GameObject settings;
    public AudioSource audioSource;

    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        audioSource.Play();
    }

    public void ChangeGraphics(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
        audioSource.Play();
    }

    public void DefaultGraphic()
    {
        QualitySettings.SetQualityLevel(0);
        audioSource.Play();
    }

    public void SwitchSound()
    { 
        AudioListener.pause = !AudioListener.pause;
        audioSource.Play();
    }

    public void Back()
    {
        menu.SetActive(true);
        settings.SetActive(false);
        audioSource.Play();
    }
}
