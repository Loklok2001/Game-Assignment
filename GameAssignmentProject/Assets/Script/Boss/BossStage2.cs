using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage2 : MonoBehaviour
{
    public Transform leftLimit;
    public Transform rightLimit;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public Transform target;
    public bool inRange;
    public GameObject hotzone;
    public GameObject triggerArea;
    public AudioClip bossAttack;
    static AudioSource audioSrc;

    private Animator animator;
    private float distance;
    private bool attackMode;
    private bool cooling;
    private float intTimer;

    private void Start()
    {
        animator.SetBool("stage2", true);
        animator.SetBool("canSeePlayer", false);
        audioSrc = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        SelectTarget();
        intTimer = timer;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!attackMode)
            Move();

        if (!InsideOfLimits() && !inRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("BossAttack"))
            SelectTarget();

        if (inRange)
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
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("BossAttack"))
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
        audioSrc.PlayOneShot(bossAttack);

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
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    public void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
            target = leftLimit;
        else
            target = rightLimit;
        Flip();
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
            rotation.y = 180f;
        else
            rotation.y = 0f;

        transform.eulerAngles = rotation;
    }
}
