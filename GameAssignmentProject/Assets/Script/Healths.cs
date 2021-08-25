using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healths : MonoBehaviour
{
    public Animator animator;
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        animator.SetTrigger("Hurt");
        if (health <= 0f) {
            health = 0f;
            PlayerDie();
        }
    }

    public void PlayerDie()
    {
        animator.SetBool("isDead", true);
        Debug.Log("Player Die");
    }
}
