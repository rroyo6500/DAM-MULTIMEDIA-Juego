using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float speed = 10;
    
    private Rigidbody2D body;
    private BoxCollider2D hitbox;
    private Rigidbody2D collisionBox;
    
    private Animator animator;

    private Vector3 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        collisionBox = transform.Find("CollisionBox").GetComponent<Rigidbody2D>();
        hitbox = transform.Find("HitBox").GetComponent<BoxCollider2D>();
        animator = transform.Find("Sprite").GetComponent<Animator>();

        movement = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(movement.x * speed *Time.fixedDeltaTime, movement.y);
        Debug.Log(movement);
    }
    
    private void ReadMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            movement = Vector3.up;
            Debug.Log("UP");
        }
        else if (Input.GetKey(KeyCode.S)) 
        {
            movement = Vector3.down;
            Debug.Log("DOWN");
        }
        else if (Input.GetKey(KeyCode.A)) 
        {
            movement = Vector3.left;
            Debug.Log("LEFT");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement = Vector3.right;
            Debug.Log("RIGHT");
        }
        else
        {
            movement = Vector3.zero;
        }
    }
}
