using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscenes : MonoBehaviour
{
    public List<GameObject> frames;
    private int id;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            frames[id].SetActive(false);
            id++;

            if (id < frames.Count)
                frames[id].SetActive(true);
            else if (id >= frames.Count)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
