using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool Ground;
    bool crouch;

    public Animator animator;
    private Rigidbody2D rb;
    public Collider2D standingCollider;
    public Transform Ceiling;
    public LayerMask Layer;
    
    const float ceilingRadius = 0.2f;
    public float moveSpeed = 1;
    public float jumpForce = 5;
    public float crouchSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //Flip player
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        //Jump
        if (Input.GetKey(KeyCode.W) && Ground)
            Jump();

        //Crouch
        if (Input.GetButton("Crouch") && Ground)
            crouch = true;
        else
            crouch = false;
        if (!crouch)
        {
            if (Physics2D.OverlapCircle(Ceiling.position, ceilingRadius, Layer))
            {
                crouch = true;
            }
        }
        Crouch();

        animator.SetBool("Walk", horizontalInput != 0);
        animator.SetBool("Ground", Ground);
        animator.SetBool("Crouch", crouch);

        if(crouch)
            rb.velocity = new Vector2(horizontalInput * crouchSpeed, rb.velocity.y);
        else
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        animator.SetTrigger("Jump");
        Ground = false;
    }

    private void Crouch()
    {
        standingCollider.enabled = !crouch;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Ground = true;
    }

}
