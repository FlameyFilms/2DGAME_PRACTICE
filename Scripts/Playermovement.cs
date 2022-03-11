using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{



    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    public GameObject dashEffect;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    public float startDashTime;
    private float Dashtime;
    public float extraSpeed;
    private bool isDashing;
    public float startDashCooldown;
    private float dashCooldown;
    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (Input.GetKey("down") &! IsGrounded())
        {
            Groundpound();
        }
        if (Input.GetKey("s") & !IsGrounded())
        {
            Groundpound();
        }
        if (Input.GetKeyDown("left shift") && isDashing == false)
        {
            if (dashCooldown <= 0 && isDashing == false)
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                moveSpeed += extraSpeed;
                isDashing = true;
                Dashtime = startDashTime;
                dashCooldown = startDashCooldown;
            }
        }
        if (Dashtime <= 0 && isDashing == true)
        {
            isDashing = false;
            moveSpeed -= extraSpeed;
        }
        else
        {
            Dashtime -= Time.deltaTime;
            dashCooldown -= Time.deltaTime;
        }
        }
    



    public void Groundpound()
    {
        if (IsGrounded() == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
