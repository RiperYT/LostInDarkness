using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerRoom : MonoBehaviour
{
    public int roomId;
    public GameObject LightMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LightMenu.GetComponent<LightMenu>().roomId = roomId;
    }
}
