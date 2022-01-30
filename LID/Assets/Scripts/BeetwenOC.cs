using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetwenOC : MonoBehaviour
{
    public GameObject hero;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hero.GetComponent<CharacterMove>().isBeetwen = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hero.GetComponent<CharacterMove>().isBeetwen = false;
    }
}
