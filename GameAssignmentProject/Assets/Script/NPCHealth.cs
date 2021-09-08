using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCHealth : MonoBehaviour
{
    public Animator animator;
    public EnemyHealthBar Healthbar;
    public Collider2D interactCollider;

    private int currentHealth;
    private int maxHealth = 150;
    private float timer = 2;
    private float times;
    bool counter;
    public static int star;

    // Start is called before the first frame update
    void Start()
    {
        counter = false;
        currentHealth = maxHealth;
        times = timer;
        Healthbar.SetHealth(currentHealth, maxHealth);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!counter)
        {
            if (times < 0)
            {
                currentHealth -= 1;
                Healthbar.SetHealth(currentHealth, maxHealth);
                times = timer;
            }
            else
                times -= Time.deltaTime;
            if (currentHealth < 0)
            {
                animator.SetBool("Dead", true);
                Destroy(Healthbar.gameObject);
                if(star == 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
                interactCollider.enabled = false;
                this.enabled = false;
            }
        }
        else {
            Destroy(Healthbar.gameObject);
            interactCollider.enabled = false;
            this.enabled = false;
        }
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public void stopcounter()
    {
        star += 1;
        counter = true;
    }
}
