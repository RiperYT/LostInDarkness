using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public GameObject door;
    public List<GameObject> books;

    private List<bool> isOpen = new List<bool>();
    private bool isCorrect = false;

    // Update is called once per frame
    void Update()
    {
        if (isOpen != null || isOpen.Count > 0)
            isOpen.Clear();

        for (var i = 0; i < books.Count; i++)
        {
            isOpen.Add(books[i].GetComponent<Book>().IsOpen);
        }

        isCorrect = true;

        foreach (var i in isOpen)
        { 
            if (!i)
                isCorrect = false;
        }

        if (isCorrect)
        {
            print("yes");
            if (door == null)
                print("fuck");
            door.GetComponent<UpperDoor>().FirstOpen();
        }
        else
        {
            string text = " ";
            foreach (var i in isOpen)
            {
                text += i + " ";
            }
            print(text);
        }
    }
}
