using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinPanel : MonoBehaviour
{
    public GameObject pressE;
    public GameObject pinCodeMenu;

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
                pinCodeMenu.SetActive(true);
            }
        }
    }

    public void Close()
    {
        hero.GetComponent<CharacterMove>().isFreezed = false;
        pinCodeMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOnTrigger = true;
        pressE.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnTrigger= false;
        pressE.SetActive(false);
    }
}
