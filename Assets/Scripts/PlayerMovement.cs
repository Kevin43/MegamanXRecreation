using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed = 0f;
    public float canMove;
    public bool stunned = false;

	// Use this for initialization
	void Start () {

        playerSpeed = 3f;


	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (stunned)
            canMove = 0;
        else
            canMove = 1;
            

        GetComponent<Rigidbody2D>().velocity = new Vector2(canMove * playerSpeed, GetComponent<Rigidbody2D>().velocity.y);

    }
}
