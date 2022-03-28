using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private float HorizontalMove = 0f;
    private bool FaceRight = true;

    public bool isFreezedAnim = false;
    private float EndTime = 0;

    public float speed = 1f;
    public float deltaTime;

    public bool isFreezed = false;

    public GameObject LightMenu;
    public GameObject LightGun;

    private float Intensity;

    public bool isBeetwen = false;
    public AudioClip[] clip;
    private AudioSource sorce;

    public States State
    {
        get { return (States)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }

    // Start is called before the first frame update
    void Start()
    {
        isFreezedAnim = false;
        isFreezed = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Intensity = LightGun.GetComponent<Light>().intensity;
        LightGun.SetActive(false);
        sorce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFreezedAnim)
        {
            if (Time.time > EndTime)
            {
                isFreezedAnim = false;
                LightGun.SetActive(false);
            }
            if (Time.time < EndTime - (deltaTime / 2))
                LightGun.GetComponent<Light>().intensity = Intensity * (Time.time - EndTime + deltaTime) / (deltaTime / 2);
            else
                LightGun.GetComponent<Light>().intensity = Intensity * (EndTime - Time.time) / (deltaTime / 2);
            State = States.dark;
            HorizontalMove = 0;
        }
        else if (!isFreezed)
        {
            
            if (Input.GetButton("Horizontal"))
                State = States.run;
            else
                State = States.idle;
            HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;
            //if (HorizontalMove != 0)
                //sorce.PlayOneShot(clip[0]);
            if (HorizontalMove < 0 && FaceRight)
            {
                
                Flip();
            }
            else if (HorizontalMove > 0 && !FaceRight)
            {
                Flip();
            }
            else if (HorizontalMove == 0)
                State = States.idle;

            if (Input.GetKeyDown(KeyCode.Space) && !isBeetwen)
            {
                LightGun.SetActive(true);
                isFreezedAnim = true;
                EndTime = Time.time + deltaTime;
                State = States.dark;
                HorizontalMove = 0;
                LightMenu.GetComponent<LightMenu>().Change(deltaTime);
            }
        }
        else
        {
            HorizontalMove = 0; 
        }
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(HorizontalMove * speed, rb.velocity.y);
        rb.velocity = targetVelocity;
    }

    private void Flip()
    {
        
        FaceRight = !FaceRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    
}

public enum States
{
    idle,
    run,
    dark
}
