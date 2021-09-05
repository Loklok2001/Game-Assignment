using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public Animator animator;
    private Rigidbody2D rb;
    public Collider2D standingCollider;
    public Collider2D crouchingCollider;
    public Transform Ceiling;
    public Transform Grounds;
    public LayerMask Layer;

    const float Radius = 0.2f;
    public float moveSpeed = 1;
    public float jumpForce = 5;
    public float crouchSpeed = 1;
    public int extraJumps = 1;
    public float dashDistance = 15f;
    int jumpCount = 0;
    float jumpCoolDown;
    bool isGround;
    bool isCrouch;
    bool isDashing;
    public bool isFacingRight = true;

    private IInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && !PauseMenu.GameIsPause)
            Jump();

        checkGrounded();

        //Dash Left
        if (!PauseMenu.GameIsPause && Input.GetButtonDown("Dash") && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))) 
        {
            StartCoroutine(Dash(-1f));
        }
        if (!PauseMenu.GameIsPause && Input.GetButtonDown("Dash") && Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            StartCoroutine(Dash(1f));
        }
        animator.SetBool("Dash", isDashing);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //Flip player
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
            isFacingRight = true;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingRight = false;
        }

        //Crouch
        if (Input.GetButton("Crouch") && isGround)
            isCrouch = true;
        else
            isCrouch = false;
        if (!isCrouch)
        {
            if (Physics2D.OverlapCircle(Ceiling.position, Radius, Layer))
            {
                isCrouch = true;
            }
        }
        Crouch();
        animator.SetBool("Walk", horizontalInput != 0);
        animator.SetBool("Ground", isGround);
        animator.SetBool("Crouch", isCrouch);
        


        if (isCrouch)
            rb.velocity = new Vector2(horizontalInput * crouchSpeed, rb.velocity.y);
        else if (!isDashing)
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (isGround || jumpCount < extraJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }
    }

    private void Crouch()
    {
        standingCollider.enabled = !isCrouch;
        crouchingCollider.enabled = isCrouch;
    }

    IEnumerator Dash (float direction)
    {
        float gravity = 5;

        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0), ForceMode2D.Impulse);
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.4f);
        isDashing = false;
        rb.gravityScale = gravity;
    }

    private void checkGrounded()
    {
        if (Physics2D.OverlapCircle(Grounds.position, 0.5f, Layer))
        {
            isGround = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.2f;
        }
        else if (Time.time < jumpCoolDown)
            isGround = true;
        else
            isGround = false;
    }

}
