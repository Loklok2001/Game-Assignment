using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealths : MonoBehaviour
{
    public Animator animator;

    private int currentHealth;
    public int maxHealth;

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
            EnemyDie();
        }
    }

    public void EnemyDie()
    {
        Debug.Log("Enemy died!");
        animator.SetBool("isDead", true);

        FindObjectOfType<itemDrop>().DropItems();

        Destroy(gameObject);
    }

}
