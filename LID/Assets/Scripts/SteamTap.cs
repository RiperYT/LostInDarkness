using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamTap : MonoBehaviour
{

    public GameObject Steam;
    public GameObject Tap;

    public GameObject pressE;

    public GameObject hero;

    private bool isOnTrigger = false;

    private bool isClose = false;
    private bool isProcessing = false;
    private float StartTime;

    public float DeltaTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isProcessing)
        {
            if (Time.time >= StartTime + DeltaTime)
            {
                hero.GetComponent<CharacterMove>().isFreezed = false;
                isProcessing = false;
                isClose = !isClose;
                if (isClose)
                {
                    Steam.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                }
                else
                {
                    Steam.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                }
            }
            else
            {
                if (!isClose)
                {
                    Steam.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 * (StartTime + DeltaTime - Time.time) / DeltaTime);
                    Tap.transform.rotation = Quaternion.Euler(0, 0, 360 * (StartTime + DeltaTime - Time.time) / DeltaTime);
                }
                else
                {
                    Steam.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 * (Time.time - StartTime) / DeltaTime);
                    Tap.transform.rotation = Quaternion.Euler(0, 0, 360 * (Time.time - StartTime) / DeltaTime);
                }
            }
        }
        else if (isOnTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E) && !hero.GetComponent<CharacterMove>().isFreezedAnim)
            {
                isProcessing = true;
                hero.GetComponent<CharacterMove>().isFreezed = true;
                hero.GetComponent<CharacterMove>().State = States.idle;
                StartTime = Time.time;
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
