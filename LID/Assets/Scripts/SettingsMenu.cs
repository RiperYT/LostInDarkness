using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject menu;
    public GameObject settings;

    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    public void ChangeGraphics(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void DefaultGraphic()
    {
        QualitySettings.SetQualityLevel(0);
    }

    public void SwitchSound()
    { 
        AudioListener.pause = !AudioListener.pause;
    }

    public void Back()
    {
        menu.SetActive(true);
        settings.SetActive(false);
    }
}
