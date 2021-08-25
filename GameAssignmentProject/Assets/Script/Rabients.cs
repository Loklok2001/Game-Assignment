using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabients : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Enemy died!");
        animator.SetBool("isDead", true);

        Destroy(gameObject);
        GetComponent<itemDrop>().DropItems();
    }
}

