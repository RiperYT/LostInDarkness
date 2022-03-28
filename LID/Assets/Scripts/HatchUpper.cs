using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HatchUpper : MonoBehaviour
{
    public GameObject pressE;

    public GameObject hero;

    private bool isOnTrigger = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOnTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E) && !hero.GetComponent<CharacterMove>().isFreezedAnim)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
