using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSound : MonoBehaviour
{

    public AudioSource[] effect;
    private float time;

    void Start()
    {
        time = Time.time + Random.Range(20, 40);

    }

    // Update is called once per frame
    void Update()
    {
        if (time < Time.time)
        {
            effect[Random.Range(0, effect.Length)].Play();
            time = Time.time + Random.Range(20, 40);
        }
        
    }
}
