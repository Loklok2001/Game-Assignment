using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHealth : MonoBehaviour
{

    public Animator animator;

    private int currentHealth;
    private int maxHealth = 150;
    public EnemyHealthBar Healthbar;
    private float timer = 2;
    private float times;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        times = timer;
        Healthbar.SetHealth(currentHealth, maxHealth);
    }

    // Update is called once per frame
    private void Update()
    {
        if (times < 0)
        {
            currentHealth -= 1;
            Healthbar.SetHealth(currentHealth, maxHealth);
            times = timer;
        }
        else
            times -= Time.deltaTime;
        if(currentHealth < 0)
        {
            animator.SetBool("Dead", true);
            Destroy(Healthbar.gameObject);
            this.enabled = false;
        }
    }

    public int getHealth()
    {
        return currentHealth;
    }
}
