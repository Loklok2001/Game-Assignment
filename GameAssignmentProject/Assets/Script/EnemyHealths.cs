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

        string name = gameObject.name.Substring(0, 3);

        if (name == "Bat")
        {
            FindObjectOfType<Bat_Sound>().Bat_hited_sound();
        }
        else if (name == "Rab")
        {
            FindObjectOfType<Zombie_Sound>().Zombie_hited_sound();
        }
    }

    public void EnemyDie()
    {
        Debug.Log("Enemy died!");
        animator.SetBool("isDead", true);
        animator.SetTrigger("isDead");

        FindObjectOfType<itemDrop>().DropItems(this.gameObject);

        string name = gameObject.name.Substring(0,3);

        if(name == "Bat")
        {
            FindObjectOfType<Bat_Sound>().Bat_died_sound();
        }
        else if(name == "Rab")
        {
            FindObjectOfType<Zombie_Sound>().Zombie_died_sound();
        }

        if (gameObject.name == "Boss")
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
