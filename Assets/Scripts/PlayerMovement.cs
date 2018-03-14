using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    public float WalkSpeed = 1f;
    public float RunSpeed = 2f;

    private float speed = 0f;
    private Vector2 movementDirection;
    private Rigidbody2D rbody;
    private Animator animator;
    private SpriteRenderer _renderer;

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
        if (!isLocalPlayer)
        {
            return;
        }
        
            if (Input.GetKeyDown(KeyCode.Q))
            animator.SetTrigger("isDying");
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("isHitting");
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
                speed = WalkSpeed;
                animator.SetBool("isRunning", false);
                            }
        }   else {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
            animator.ResetTrigger("isHitting");
        }
        movementDirection = dir.normalized * speed;
    }

    public override void OnStartLocalPlayer()
    {
        GameObject.Find("CM vcam1").GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = transform;
        //GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}