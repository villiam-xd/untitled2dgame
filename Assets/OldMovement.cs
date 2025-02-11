using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMovement : MonoBehaviour
{
    
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

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Movement()
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
