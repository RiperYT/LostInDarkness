using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player;
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
        pos.y += 2.5f;

        transform.position = Vector3.Lerp(transform.position, pos, 15 * Time.deltaTime);

    }
}
