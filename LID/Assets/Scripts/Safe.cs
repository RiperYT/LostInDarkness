using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    public GameObject pressE;
    public GameObject safeMenu;

    public GameObject hero;

    private bool isOnTrigger = false;

    // Update is called once per frame
    void Update()
    {
        if (isOnTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E) && !hero.GetComponent<CharacterMove>().isFreezedAnim)
            {
                hero.GetComponent<CharacterMove>().isFreezed = true;
                safeMenu.SetActive(true);
            }
        }
    }

    public void Close()
    {
        hero.GetComponent<CharacterMove>().isFreezed = false;
        safeMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOnTrigger = true;
        pressE.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnTrigger = false;
        pressE.SetActive(false);
    }
}
