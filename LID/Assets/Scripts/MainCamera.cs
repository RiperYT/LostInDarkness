using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player;
    public float plus = 3f;
    private Vector3 pos;

    /*private void Awake()
    {
        if (!player)
            player = FindObjectOfType<Hero>().transform;
    }*/

    void Update()
    {

        pos = player.position;
        pos.z = -200f;
        pos.y += plus;

        transform.position = Vector3.Lerp(transform.position, pos, 15 * Time.deltaTime);

    }
}
