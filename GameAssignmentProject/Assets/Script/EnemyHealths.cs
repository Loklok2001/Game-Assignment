using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealths : MonoBehaviour
{
    public Animator animator;

    private int currentHealth;
    public int maxHealth;
    public EnemyHealthBar Healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Healthbar.SetHealth(currentHealth, maxHealth);
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Healthbar.SetHealth(currentHealth, maxHealth);
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
        animator.SetTrigger("isDead");

        FindObjectOfType<itemDrop>().DropItems(this.gameObject);

        if(gameObject.name == "Boss")
        {
            FindObjectOfType<ShowChest>().DisplayChest();
        }
        
        Destroy(gameObject, 0.3f);
    }

    public int getHealth()
    {
        return currentHealth;
    }
}
