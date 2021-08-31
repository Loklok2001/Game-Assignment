using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabients : MonoBehaviour
{
    public Transform rayCast;
    public Transform left;
    public Transform right;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;

    private RaycastHit2D hit;
    private Transform target;
    private Animator animator;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;

    private void Awake()
    {
        SelectTarget();
        intTimer = timer;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!attackMode)
            Move();

        if (!InsideOfLimits() && inRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("RabientAttackLeft"))
            SelectTarget();

        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, raycastMask);
            RayCastDebugger();
        }

        if (hit.collider != null)
            EnemyLogic();
        else if (hit.collider == null)
            inRange = false;

        if(inRange == false)
        {
            StopAttack();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);
        if (distance > attackDistance)
        {
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
            Attack();

        if (cooling)
        {
            Cooldown();
            animator.SetBool("Attack", false);
        }
    }

    void Move()
    {
        animator.SetBool("canWalk", true);
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("RabientAttackLeft"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        animator.SetBool("canWalk", false);
        animator.SetBool("Attack", true);
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        animator.SetBool("Attack", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = collision.transform;
            inRange = true;
            Flip();
        }
    }

    void RayCastDebugger()
    {
        if (distance > attackDistance)
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red);
        else if(attackDistance > distance)
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.green);
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideOfLimits()
    {
        return transform.position.x > left.position.x && transform.position.x < right.position.x;
    }

    private void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, left.position);
        float distanceToRight = Vector2.Distance(transform.position, right.position);

        if (distanceToLeft > distanceToRight)
            target = left;
        else
            target = right;
        Flip();
    }

    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
            rotation.y = 180f;
        else
            rotation.y = 0f;

        transform.eulerAngles = rotation;
    }
}

