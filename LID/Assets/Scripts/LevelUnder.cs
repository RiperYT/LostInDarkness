using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnder : MonoBehaviour
{

    private bool First = false;
    private bool Second = false;
    private bool Third = false;
    public GameObject FirstDoor;
    public GameObject SecondDoor;
    public GameObject ThirdDoor;

    public void OpenFirst()
    {
        if (FirstDoor == false)
        {
            First = true;
            FirstDoor.GetComponent<DoorOC>().OpenTheDoor();
        }
    }
    public void OpenSecond()
    {
        if (FirstDoor == false)
        {
            Second = true;
            SecondDoor.GetComponent<DoorOC>().OpenTheDoor();
        }
    }
    public void OpenThird()
    {
        if (FirstDoor == false)
        {
            Third = true;
            ThirdDoor.GetComponent<DoorOC>().OpenTheDoor();
        }
    }
}
