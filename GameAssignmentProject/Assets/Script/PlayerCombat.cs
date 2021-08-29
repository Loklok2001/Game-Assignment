using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    PlayerController ps;

    public Animator animator;
    public Transform attackPoint;
    public Transform firingPoint;
    public LayerMask enemyLayer;
    public GameObject bullet;

    public int attackDamage = 5;
    public float attackRange = 0.5f;
    public float attackrate = 2f;
    float nextAttackTime = 0f;
    float timeUntilFire;
    public float fireRate = 0.2f;

    private void Start()
    {
        ps = gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Attack") && Time.time >= nextAttackTime && !PauseMenu.GameIsPause)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackrate;
        }
        if (Input.GetButtonDown("Fire") && Time.time > timeUntilFire && !PauseMenu.GameIsPause)
        {
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }

    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealths>().TakeDamage(attackDamage);
        }
    }

    void Shoot()
    {
        float angle = ps.isFacingRight ? 0f : 180f;
        Instantiate(bullet, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
