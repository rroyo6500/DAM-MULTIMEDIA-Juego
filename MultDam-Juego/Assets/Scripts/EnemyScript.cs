using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    
    public float speed = 10;
    public GameObject player;
    private Rigidbody2D playerBody;
    
    private Rigidbody2D body;
    private BoxCollider2D hitbox;
    
    private Animator animator;

    private Vector3 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        hitbox = transform.Find("HitBox").GetComponent<BoxCollider2D>();
        animator = transform.Find("Sprite").GetComponent<Animator>();

        movement = Vector3.zero;
        
        playerBody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(movement.x * speed * Time.fixedDeltaTime, movement.y * speed * Time.fixedDeltaTime);
    }

    private void ReadMovement()
    {
        movement = Vector3.zero;
        
        Vector2 vec = playerBody.position - body.position;
        
        movement = vec;
        
    }
}
