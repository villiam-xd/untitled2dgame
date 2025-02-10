using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
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
        if (Mathf.Abs(body.velocity.x) < maxSpeed && collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            body.AddForce(move * acceleration * Time.deltaTime);
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
        
        move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                body.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
            }
        }
    }

    void OldMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
                {
                    if(body.velocity.y == 0 || true)
                    {
                        body.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

                    }
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                if (body.velocity.x > 0)
                {
                    body.velocity = new Vector2(0, body.velocity.y);
                }
                Debug.Log("A key pressed");
                body.AddForce(Vector2.left * 20, ForceMode2D.Impulse);
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (body.velocity.x < 0)
                {
                    body.velocity = new Vector2(0, body.velocity.y);
                }
                Debug.Log("D key pressed");
                body.AddForce(Vector2.right * 20, ForceMode2D.Impulse);
            }
        }
    }
}
