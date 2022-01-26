using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    Text textWindow;
    string visibleText = "";
    public string password;
    public bool isCorrect = false;

    // Start is called before the first frame update
    void Start()
    {
        textWindow = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textWindow.text = visibleText;

        if (visibleText == password)
        {
            isCorrect = true;
        }
    }

    public void AddNumber(string num)
    {
        if (!isCorrect)
        {
            if (visibleText == "----")
                visibleText = "";

            if (visibleText.Length < 4)
            {
                visibleText += num;
            }
            else
            {
                visibleText = "----";
            }
        }
    }
}
