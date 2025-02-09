using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Collider2D collider;
    public Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                //Debug.Log(body.velocity.y);
                if(body.velocity.y == 0)
                {
                    body.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

                }
                else
                {
                    Debug.Log("LMAO");
                }
                //Debug.Log("Is Touching Ground");
                
            }
            //Debug.Log("W key pressed");

        }
        //if (Input.GetKey(KeyCode.S))
        //{
        //    Debug.Log("S key pressed");
        //    this.gameObject.transform.Translate(Vector3.down * Time.deltaTime * 5);
        //}
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A key pressed");
            if(body.velocity.x < 0.1)
            {
                body.AddForce(Vector2.left);
            }
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D key pressed");
            if (body.velocity.x > -0.1)
            {
                body.AddForce(Vector2.right);
            }
        }
    }
}
