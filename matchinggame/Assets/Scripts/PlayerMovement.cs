using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]public float speed;
    public Rigidbody body;
    public Animator anim;

    private void Awake()
    {
        //Grab reference for ridgidbody and animator from object
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed,body.velocity.y);
        
        //flippies!!
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(3,3, 5);
        
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-3,3, 5);
            
        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);
        
        //Set animator parameters
        anim.SetBool("Run", horizontalInput != 0);
    }
}

