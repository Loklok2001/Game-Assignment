using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabients : MonoBehaviour
{
    public Transform left;
    public Transform right;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public Transform target;
    public bool inRange;
    public GameObject hotzone;
    public GameObject triggerArea;

    private Animator animator;
    private float distance;
    private bool attackMode;
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

        if (!InsideOfLimits() && !inRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("RabientAttackLeft"))
            SelectTarget();

        if(inRange)
        {
            EnemyLogic();
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

    public void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideOfLimits()
    {
        return transform.position.x > left.position.x && transform.position.x < right.position.x;
    }

    public void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, left.position);
        float distanceToRight = Vector2.Distance(transform.position, right.position);

        if (distanceToLeft > distanceToRight)
            target = left;
        else
            target = right;
        Flip();
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
            rotation.y = 0f;
        else
            rotation.y = 180f;

        transform.eulerAngles = rotation;
    }
}

