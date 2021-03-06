using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMenu : MonoBehaviour
{
    public GameObject LightGun;

    public List<GameObject> ListLightMode1;
    public List<GameObject> ListLightMode2;
    public List<GameObject> ListLightMode3;
    public List<GameObject> ListLightMode4;

    public List<GameObject> ListHintMode1;
    public List<GameObject> ListHintMode2;
    public List<GameObject> ListHintMode3;
    public List<GameObject> ListHintMode4;

    public int roomId;
    void Start()
    {
        roomId = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Change(float deltaTime)
    {
        if(roomId == 1)
        foreach (GameObject obj in ListLightMode1)
            obj.GetComponent<LightMode>().Changed(deltaTime, LightGun);
        if (roomId == 2)
            foreach (GameObject obj in ListLightMode2)
                obj.GetComponent<LightMode>().Changed(deltaTime, LightGun);
        if (roomId == 3)
            foreach (GameObject obj in ListLightMode3)
                obj.GetComponent<LightMode>().Changed(deltaTime, LightGun);
        if (roomId == 4)
            foreach (GameObject obj in ListLightMode4)
                obj.GetComponent<LightMode>().Changed(deltaTime, LightGun);

        if (roomId == 1)
            foreach (GameObject obj in ListHintMode1)
                obj.GetComponent<Hint>().Changed(deltaTime, LightGun);
        if (roomId == 2)
            foreach (GameObject obj in ListHintMode2)
                obj.GetComponent<Hint>().Changed(deltaTime, LightGun);
        if (roomId == 3)
            foreach (GameObject obj in ListHintMode3)
                obj.GetComponent<Hint>().Changed(deltaTime, LightGun);
        if (roomId == 4)
            foreach (GameObject obj in ListHintMode4)
                obj.GetComponent<Hint>().Changed(deltaTime, LightGun);
    }
}
