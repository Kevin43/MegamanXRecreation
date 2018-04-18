using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Transform groundCheck;

    public float jumpForce = 120f;
    public float playerSpeed = 0f;
    public float move;
    public float groundRadius = 0.2f;
    public bool stunned = false;
    public bool facingRight = true;
    public bool grounded = false;
    public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {

        playerSpeed = 3f;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float move = Input.GetAxis("Horizontal");

        if (move < 0) GetComponent<Rigidbody2D>().velocity = new Vector3(move * playerSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (move > 0) GetComponent<Rigidbody2D>().velocity = new Vector3(move * playerSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (grounded && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            //schedulePlay(sound.mm_jump);
            //anim.SetBool("Grounded", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
        //if (stunned)
        //    move = 0;
        //else
        //    move = 1;


        //GetComponent<Rigidbody2D>().velocity = new Vector2(move * playerSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }
    void Update ()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
