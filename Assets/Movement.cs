using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public float jumpForce;
    private Vector2 move;
    
    //Player object components
    Collider2D collider;
    Rigidbody2D body;
    Animator animator;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        //Player moves on input if touching ground and speed slower than max speed
        if (Mathf.Abs(body.velocity.x) < maxSpeed && collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            //move is equal to 0 when no input, 1 when right input and -1 when left input
            body.AddForce(move * acceleration * Time.deltaTime);
        }

        if (Mathf.Abs(body.velocity.x) > 30 && collider.IsTouchingLayers(LayerMask.GetMask("Wall")))
        {
            Debug.Log("lmao");
        }
    }

    void Update()
    {
        //Determines player speed to play running animation
        animator.SetFloat("Speed", Mathf.Abs(body.velocity.x));
        
        //Flips sprite depending on running direction
        if (body.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (body.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        
        //Gets horizontal input direction
        move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        //Jumps if player is touching ground
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 velocity = other.relativeVelocity;
        Debug.Log(other.relativeVelocity);
    }
}
