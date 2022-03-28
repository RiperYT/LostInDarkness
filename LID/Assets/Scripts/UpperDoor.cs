using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperDoor : MonoBehaviour
{
    public GameObject door;
    public GameObject emptyDoor;
    public GameObject beetwen;
    public GameObject dark;

    

    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        emptyDoor.SetActive(true);
        door.SetActive(false);
        beetwen.SetActive(false);
        dark.SetActive(true);
        isOpen = false;
    }

    public void FirstOpen()
    {
        if (!isOpen)
        {
            emptyDoor.SetActive(false);
            door.SetActive(true);
            beetwen.SetActive(true);
            dark.SetActive(false); 
            isOpen = true;
        }
    }
    public void FirstClose()
    {
        if (isOpen)
        {
            emptyDoor.SetActive(true);
            door.SetActive(false);
            beetwen.SetActive(false);
            dark.SetActive(true); 
            isOpen = false;
        }
    }
}
