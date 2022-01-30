using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public GameObject book;
    public GameObject openBook;

    public bool IsOpen = false;

    public void Use()
    {
        IsOpen = !IsOpen;
        book.SetActive(!book.activeSelf);
        openBook.SetActive(!openBook.activeSelf);
    }
}
