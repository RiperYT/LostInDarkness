using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMenu : MonoBehaviour
{
    private bool[] arms = new bool[5];
    public bool[] armsAns = { false, false, true, true, false };
    public GameObject LevelUnder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change(int n, bool p)
    {
        arms[n-1] = p;
        bool a = true;
        for(int i = 0; i < arms.Length; i++)
            if(arms[i]!=armsAns[i])
                a = false;
        if (a)
            LevelUnder.GetComponent<LevelUnder>().OpenThird();
    }
}
