using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMode : MonoBehaviour
{
    private GameObject LightGun;

    public GameObject DarkSprite;
    public GameObject LightSprite;

    public GameObject PointSmall;
    public GameObject PointLarge;

    private float SmallIntensity;
    private float LargeIntensity;
    private float SmallRange;
    private float LargeRange;

    private Vector3 StartSmall;
    private Vector3 StartLarge;

    private bool isChanging = false;
    private bool needChanging = true;

    private float StartTime;
    private float DeltaTime;

    public AudioSource effect;

    // Start is called before the first frame update
    void Start()
    {
        SmallIntensity = PointSmall.GetComponent<Light>().intensity;
        LargeIntensity = PointLarge.GetComponent<Light>().intensity;
        SmallRange = PointSmall.GetComponent<Light>().range;
        LargeRange = PointLarge.GetComponent<Light>().range;
        DarkSprite.SetActive(false);
        LightSprite.SetActive(true);
        StartSmall = PointSmall.transform.position;
        StartLarge = PointLarge.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChanging)
        {
            if(Time.time >= StartTime + DeltaTime)
            {
                if (needChanging)
                {
                    PointSmall.GetComponent<Light>().intensity = SmallIntensity;
                    PointLarge.GetComponent<Light>().intensity = LargeIntensity;
                    PointSmall.transform.position = StartSmall;
                    PointLarge.transform.position = StartLarge;
                    isChanging = false;
                }
                else
                {
                    PointSmall.GetComponent<Light>().intensity = 0;
                    PointLarge.GetComponent<Light>().intensity = 0;
                    DarkSprite.SetActive(true);
                    LightSprite.SetActive(false);
                    PointSmall.transform.position = new Vector3(LightGun.transform.position.x, LightGun.transform.position.y, LightGun.transform.position.z);
                    PointLarge.transform.position = new Vector3(LightGun.transform.position.x, LightGun.transform.position.y, LightGun.transform.position.z);
                    isChanging = false;
                }
            }
            else
            {
                
                    if (needChanging)
                    {
                        PointSmall.GetComponent<Light>().intensity = SmallIntensity * (Time.time - StartTime ) / (DeltaTime );
                        PointLarge.GetComponent<Light>().intensity = LargeIntensity * (Time.time - StartTime ) / (DeltaTime );

                    PointSmall.GetComponent<Light>().range = SmallRange * (Time.time - StartTime) / (DeltaTime);
                    PointLarge.GetComponent<Light>().range = LargeRange * (Time.time - StartTime) / (DeltaTime);

                    PointSmall.transform.position = new Vector3(LightGun.transform.position.x + (StartSmall.x - LightGun.transform.position.x ) * (Time.time - StartTime) / (DeltaTime),
                             LightGun.transform.position.y + (StartSmall.y - LightGun.transform.position.y) * (Time.time - StartTime) / (DeltaTime),
                             LightGun.transform.position.z + (StartSmall.z - LightGun.transform.position.z) * (Time.time - StartTime) / (DeltaTime));
                    PointLarge.transform.position = new Vector3(LightGun.transform.position.x + (StartLarge.x - LightGun.transform.position.x) * (Time.time - StartTime) / (DeltaTime),
                         LightGun.transform.position.y + (StartLarge.y - LightGun.transform.position.y) * (Time.time - StartTime) / (DeltaTime),
                         LightGun.transform.position.z + (StartLarge.z - LightGun.transform.position.z) * (Time.time - StartTime) / (DeltaTime));

                    /*PointSmall.transform.position = new Vector3(LightGun.transform.position.x + (StartSmall.x - LightGun.transform.position.x) * (Time.time - StartTime) / (DeltaTime / 2),
                            LightGun.transform.position.y + (StartSmall.y - LightGun.transform.position.y) * (Time.time - StartTime) / (DeltaTime / 2), StartSmall.z);
                        PointLarge.transform.position = new Vector3(LightGun.transform.position.x + (StartLarge.x - LightGun.transform.position.x) * (Time.time - StartTime) / (DeltaTime / 2),
                            LightGun.transform.position.y + (StartLarge.y - LightGun.transform.position.y) * (Time.time - StartTime) / (DeltaTime / 2), StartLarge.z);*/
                    }
                    else
                    {
                        PointSmall.GetComponent<Light>().intensity = SmallIntensity - SmallIntensity * (Time.time - StartTime ) / (DeltaTime );
                        PointLarge.GetComponent<Light>().intensity = LargeIntensity - LargeIntensity * (Time.time - StartTime  ) / (DeltaTime );

                        PointSmall.GetComponent<Light>().range = SmallRange - SmallRange * (Time.time - StartTime ) / (DeltaTime );
                        PointLarge.GetComponent<Light>().range = LargeRange - LargeRange * (Time.time - StartTime ) / (DeltaTime );

                        PointSmall.transform.position = new Vector3(StartSmall.x + (LightGun.transform.position.x - StartSmall.x ) * (Time.time - StartTime ) / (DeltaTime),
                            StartSmall.y + (LightGun.transform.position.y - StartSmall.y) * (Time.time - StartTime ) / (DeltaTime ), 
                            StartSmall.z + (LightGun.transform.position.z - StartSmall.z) * (Time.time - StartTime ) / (DeltaTime ));
                        PointLarge.transform.position = new Vector3(StartLarge.x + (LightGun.transform.position.x - StartLarge.x) * (Time.time - StartTime ) / (DeltaTime ),
                            StartLarge.y + (LightGun.transform.position.y - StartLarge.y) * (Time.time - StartTime ) / (DeltaTime ),                            
                            StartLarge.z + (LightGun.transform.position.z - StartLarge.z) * (Time.time - StartTime ) / (DeltaTime ));

                    }
                
            }

        }
    }

    public void Changed(float deltaTime, GameObject lightGun)
    {
        effect.Play();
        if (needChanging)
            needChanging = false;
        else
        {
            needChanging = true;
            DarkSprite.SetActive(false);
            LightSprite.SetActive(true);
        }

        StartTime = Time.time;
        DeltaTime = deltaTime;
        isChanging = true;
        LightGun = lightGun;
    }
}
