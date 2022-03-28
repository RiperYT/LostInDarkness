using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePassword : MonoBehaviour
{
    /*enum Side
    { 
        Left = 0,
        Right = 1
    }

    public float speed;
    public int miss;
    public List<int> password;
    public List<bool> passwordSide;*/
    public GameObject door;
    public Camera camera;
    /*
    private Vector2 first;
    private Transform thisTransform;

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
        correct = 0;
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
    }*/

    public int numbflip = 1;
    public bool flip = true;
    private float z = 0;
    public float speed;
    public float miss;

    private int first = 115;
    private int second = -38;
    private int third = -156;
    private bool isReady = false;

    private void Update()
    {
        if(!isReady)
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            z -= speed;
            if (z < -180)
                z = 360 + z;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, z);
            float k = z + 70;
            if (k > 180)
                k = -360 + k;
            if (!flip)
                //gameObject.transform.rotation = Quaternion.Euler(0, 0, z);
            {
                if(numbflip == 1)
                {
                    if (k < first + miss && k > first - miss)
                        numbflip = 2;
                } else if (numbflip == 3)
                {
                        if (k < third + miss && k > third - miss)
                        {
                            door.GetComponent<LevelUnder>().OpenSecond();
                            isReady = true;
                        }
                        else
                        {
                            Debug.Log(k);
                            Debug.Log(third - miss);
                            Debug.Log(third + miss);
                            numbflip = 1;
                        }
                }
            }
            flip = true;

        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            z += speed;
            if (z > 180)
                z = -360 + z;
            float k = z + 70;
            if (k > 180)
                k = -360 + k;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, z);
                if (numbflip == 3)
                {
                    if (k < third + miss && k > third - miss)
                    {
                        door.GetComponent<LevelUnder>().OpenSecond();
                        isReady = true;
                    }
                }
                    if (flip)
                //gameObject.transform.rotation = Quaternion.Euler(0, 0, z);
            {
                if (numbflip == 2)
                {
                    if (k < second + miss && k > second - miss)
                        numbflip = 3;
                    else
                        numbflip = 1;
                }
            }
            flip = false;
        }
    }

}
