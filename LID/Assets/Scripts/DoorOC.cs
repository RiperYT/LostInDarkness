using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOC : MonoBehaviour
{
    public GameObject OpenDoor;
    public GameObject CloseDoor;
    public bool Open = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Open == false)
        {
            OpenDoor.SetActive(false);
            CloseDoor.SetActive(true);
        }
        else
        {
            OpenDoor.SetActive(true);
            CloseDoor.SetActive(false);
        }
    }

    public void OpenTheDoor()
    {
        OpenDoor.SetActive(true);
        CloseDoor.SetActive(false);
        Open = true;
    }

    public void CloseTheDoor()
    {
        OpenDoor.SetActive(false);
        CloseDoor.SetActive(true);
        Open = false;
    }
}
