using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healths : MonoBehaviour
{
    public Animator animator;
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;

    public void Start()
    {
        health = maxHealth;
        animator.SetBool("isDead", false);
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
        StartCoroutine(Respawn());
        Debug.Log("Player Die");
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<LevelManager>().Respawn();
    }

    public void heal()
    {
        health += 10;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
