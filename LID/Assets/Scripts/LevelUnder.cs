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

    public GameObject SecondDark;
    public GameObject ThirdDark;

    public AudioSource first;
    public AudioSource second;
    public AudioSource third;

    private void Start()
    {
        First = false;
        FirstDoor.GetComponent<DoorOC>().CloseTheDoor();

        Second = false;
        SecondDoor.GetComponent<DoorOC>().CloseTheDoor();

        Third = false;
        ThirdDoor.GetComponent<HatchOC>().CloseTheDoor();

        SecondDark.SetActive(true);
        ThirdDark.SetActive(true);
    }

    public void OpenFirst()
    {
        if (First == false)
        {
            First = true;
            first.Play();
            FirstDoor.GetComponent<DoorOC>().OpenTheDoor();
            SecondDark.SetActive(false);

        }
    }
    public void OpenSecond()
    {
        if (Second == false)
        {
            Second = true;
            second.Play();
            SecondDoor.GetComponent<DoorOC>().OpenTheDoor();
            ThirdDark.SetActive(false);
        }
    }
    public void OpenThird()
    {
        if (Third == false)
        {
            Third = true;
            third.Play();
            ThirdDoor.GetComponent<HatchOC>().OpenTheDoor();
        }
    }
}
