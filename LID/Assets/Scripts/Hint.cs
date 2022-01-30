using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    private bool isClose = true;
    private bool isProcessing = false;
    private float StartTime;

    public float DeltaTime;

    void Start()
    {
        //gameObject.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isProcessing)
        {
            if (Time.time >= StartTime + DeltaTime)
            {
                isProcessing = false;
                isClose = !isClose;
                if (isClose)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                }
            }
            else
            {
                if (!isClose)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 * (StartTime + DeltaTime - Time.time) / DeltaTime);
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 * (Time.time - StartTime) / DeltaTime);
                }
            }
        }

    }

    public void Changed(float deltaTime, GameObject lightGun)
    {
        isProcessing = true;

        StartTime = Time.time;
        DeltaTime = deltaTime;
    }

}
