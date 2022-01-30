using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    public GameObject menu;
    public GameObject settings;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0f)
                Time.timeScale = 1f;
            else
                Time.timeScale = 0f;

            menu.SetActive(true);
            settings.SetActive(false);

            pause.SetActive(!pause.active);
        }
    }
}
