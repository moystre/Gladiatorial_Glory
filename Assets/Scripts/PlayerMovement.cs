﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float WalkSpeed = 1f;
    public float RunSpeed = 2f;

    private float speed = 0f;
    private Vector2 movementDirection;
    private Rigidbody2D rbody;
    private Animator animator;
    private SpriteRenderer _renderer;

//    public bool isWalking = false;
//    public bool isRunning = false;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        speed = WalkSpeed;
    }



    private void FixedUpdate()
    {
        rbody.velocity = movementDirection;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            animator.SetTrigger("Die");
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
            movementDirection = Vector2.zero;
        }
        else
            Move();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x < 0f)
            _renderer.flipX = true;
        else if (x > 0f)
            _renderer.flipX = false;

        Vector2 dir = new Vector2(x, y);
        speed = 0f;
        if (dir.magnitude > 0f)
        {
            animator.SetBool("isWalking", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = RunSpeed;
                animator.SetBool("isRunning", true);
         
            }
            else
            {
              
                animator.SetBool("isRunning", false);
                speed = WalkSpeed;
             
            }
        }else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
        }
        movementDirection = dir.normalized * speed;
    }
}