using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePassword : MonoBehaviour
{
    enum Side
    { 
        Left = 0,
        Right = 1
    }

    public float speed;
    public int miss;
    public List<int> password;
    public List<bool> passwordSide;
    public GameObject door;

    private Vector2 first;
    private Transform thisTransform;
    private Camera camera;

    private float previousAngle = 0f;
    private int id;
    private bool isActive = true;
    private int correct = 0;

    // Start is called before the first frame update
    void Start()
    {
        first = Vector2.up;
        camera = Camera.main;
        thisTransform = transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isActive = true;
        }
    }

    public void Rotate()
    {
        if (correct != password.Count)
        {
            if (isActive)
            {
                Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
                Vector2 objectPos = thisTransform.position;

                Vector2 direction = mousePos - objectPos;
                direction.Normalize();

                first = Vector2.Lerp(first, direction, Time.deltaTime * speed);
                thisTransform.up = first;

                float z = thisTransform.rotation.eulerAngles.z;

                if (CheckSide(z) != null)
                {
                    if (CheckSide(z) == true)
                    {
                        if (Check(z))
                        {
                            correct++;
                            id++;
                        }
                    }
                    else
                    {
                        Restart();
                    }

                }

                previousAngle = z;
            }
        }
        else
        {
            door.GetComponent<LevelUnder>().OpenSecond();
        }
    }

    public void Restart()
    {
        id = 0;
        thisTransform.rotation = Quaternion.Euler(0, 0, 0);
        correct = 0;
        isActive = false;
    }

    public void StartRotating()
    {
        isActive = true;
    }


    private bool? CheckSide(float z)
    {
        Side side = 0;
        Side temp;

        if (passwordSide[id])
            temp = Side.Right;
        else
            temp = Side.Left;

        if (previousAngle > miss && previousAngle < (360 - miss) && z > miss && z < (360 - miss))
        {
            int passAngle = Translate(password[id]);

            if (z >= (passAngle - miss) && z <= (passAngle + miss))
            {
                if (z > previousAngle)
                    side = Side.Left;
                else if (z < previousAngle)
                    side = Side.Right;

                if (side == temp)
                    return true;
                else
                    return false;
            }
            else
            {
                return null;
            }
        }
        else return null;
    }

    private bool Check(float angle)
    {
        int passAngle = Translate(password[id]);

        if (angle >= (passAngle - miss) && angle <= (passAngle + miss))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private int Translate(int num)
    {
        int temp = num * 40;
        temp += 293;

        if (temp >= 360)
            temp -= 360;

        return temp;
    }
}
