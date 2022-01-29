using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private float HorizontalMove = 0f;
    private bool FaceRight = true;

    public float speed = 1f;

    public bool isFreezed = false;


    private States State
    {
        get { return (States)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }

    // Start is called before the first frame update
    void Start()
    {
        isFreezed = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFreezed)
        {
            if (Input.GetButton("Horizontal"))
                State = States.run;
            else
                State = States.idle;
            HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;

            if (HorizontalMove < 0 && FaceRight)
                Flip();
            else if (HorizontalMove > 0 && !FaceRight)
                Flip();
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
    run
}
