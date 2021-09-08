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
    public AudioClip attackSound;
    public AudioClip fireSound;
    public bool attack = false;
    static AudioSource audioSrc;

    public int attackDamage = 5;
    public float attackRange = 0.5f;
    public float attackrate = 2f;
    float nextAttackTime = 0f;
    float timeUntilFire;
    public float fireRate = 0.2f;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        ps = gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Attack") && Time.time >= nextAttackTime && !PauseMenu.GameIsPause && !Chest.isOpen)
        {
            Attack();
            attack = true;
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
        audioSrc.PlayOneShot(attackSound);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealths>().TakeDamage(attackDamage);
        }
    }

    void Shoot()
    {
        animator.SetTrigger("Shoot");
        audioSrc.PlayOneShot(fireSound);
        float angle = ps.isFacingRight ? 0f : 180f;
        Instantiate(bullet, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }

}
