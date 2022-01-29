using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    //private int timer;
    private bool isEnd = false;
    private bool isStart = false;
    private bool isCorrect = false;

    private float EndTime1 = 0;
    private float EndTime2 = 0;

    Text textWindow;
    string visibleText = "";
    public string password;

    public float beforeTimer;
    public float afterTimer;

    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        textWindow = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCorrect)
        {
            textWindow.text = visibleText;

            if (textWindow.text.ToString().Length != 4)
            {
                var l = textWindow.text.ToString().Length;
                for (var i = 0; i < (4 - l); i++)
                {
                    textWindow.text += "-";
                }
            }

            if (!isStart && !isEnd)
            {
                if (visibleText == password)
                {
                    isCorrect = true;
                    door.GetComponent<LevelUnder>().OpenFirst();
                }
                else if (visibleText.Length >= 4)
                {
                    isStart = true;
                    EndTime1 = Time.time + beforeTimer;

                    isEnd = true;
                    EndTime2 = EndTime1 + afterTimer;
                }
            }
            else if (isStart && Time.time >= EndTime1)
            {
                isStart = false;
                visibleText = "NOPE";
            }
            else if (isEnd && Time.time >= EndTime2)
            {
                isEnd = false;
                visibleText = "";
            }
        }
        else
        {
            textWindow.text = "YEAP";
        }
    }

    public void AddNumber(string num)
    {
        if (!isCorrect)
        {
            if (visibleText.Length < 4)
            {
                visibleText += num;
            }
        }
    }
}
