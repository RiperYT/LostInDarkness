using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMode : MonoBehaviour
{
    private bool isOnTrigger;
    public bool mode;
    public int number;

    public GameObject spriteOn;
    public GameObject spriteOff;

    public GameObject pressE;

    public GameObject hero;

    public GameObject ArmMenu;
    // Start is called before the first frame update
    void Start()
    {
        if (mode)
        {
            spriteOn.SetActive(true);
            spriteOff.SetActive(false);
        }
        else
        {
            spriteOn.SetActive(false);
            spriteOff.SetActive(true);
        }
        ArmMenu.GetComponent<ArmMenu>().Change(number, mode);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E) && !hero.GetComponent<CharacterMove>().isFreezedAnim)
            {
                mode = !mode;
                if (mode)
                {
                    spriteOn.SetActive(true);
                    spriteOff.SetActive(false);
                }
                else
                {
                    spriteOn.SetActive(false);
                    spriteOff.SetActive(true);
                }
                ArmMenu.GetComponent<ArmMenu>().Change(number, mode);

            }
        }
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
