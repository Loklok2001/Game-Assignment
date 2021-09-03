using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float moveSpeed = 1;
    public float jumpHeight;
    public Transform groundCheckPoint;
    public Transform wallCheckPoint;
    public Transform groundedCheckPoint;
    public EnemyHealths health;
    public Transform player;
    public float circleRadius;
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    public Vector2 boxSize;
    public Vector2 lineOfSite;
    public Animator animator;

    private bool stage2 = false;
    private bool checkingWall;
    private bool checkingGround;
    private bool isGrounded;
    private bool canSeePlayer;
    private float moveDirection = 1;
    private bool facingRight = true;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health.getHealth() < (health.maxHealth / 2))
            this.enabled = false;

        checkingGround = Physics2D.OverlapCircle(groundCheckPoint.position, circleRadius, groundLayer);
        checkingWall = Physics2D.OverlapCircle(wallCheckPoint.position, circleRadius, groundLayer);
        isGrounded = Physics2D.OverlapBox(groundedCheckPoint.position, boxSize, 0, groundLayer);
        canSeePlayer = Physics2D.OverlapBox(transform.position, lineOfSite, 0, playerLayer);

        animator.SetBool("canSeePlayer", canSeePlayer);
        animator.SetBool("isGrounded", isGrounded);

        if(!canSeePlayer && isGrounded)
            Patrolling();
        
    }

    void Patrolling()
    {
        if(!checkingGround || checkingWall)
        {
            if (facingRight)
                Flip();
            else if (!facingRight)
                Flip();
        }
        rb.velocity = new Vector2(moveSpeed * moveDirection, rb.velocity.y);
    }

    void JumpAttack()
    {
            float distanceFromPlayer = player.position.x - transform.position.x;
            if (isGrounded)
            {
                rb.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
            }
    }

    void FlipTowardsPlayer()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;

        if (distanceFromPlayer < 0 && facingRight)
            Flip();

        else if (distanceFromPlayer > 0 && !facingRight)
            Flip();
    }

    void Flip()
    {
        moveDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheckPoint.position, circleRadius);
        Gizmos.DrawWireSphere(wallCheckPoint.position, circleRadius);
        Gizmos.DrawCube(groundedCheckPoint.position, boxSize);
        Gizmos.DrawWireCube(transform.position, lineOfSite);
    }
}
