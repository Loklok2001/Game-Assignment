using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healths : MonoBehaviour
{
    public Animator animator;
    private float health = 0f;
    [SerializeField] private float maxHealth = 20f;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public AudioClip potionSound;
    static AudioSource audioSrc;

    public GameObject diedUI; 

    public void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        health = maxHealth;
        animator.SetBool("isDead", false);
    }

    private void Update()
    {
  
        int currenthp = (int)health / 2;//9.5 = 9
        int halfHp = (int)System.Math.Ceiling(health / 2);


        for (int i = 0; i< hearts.Length; i++)
        {

            if (i < currenthp)          //i < 9 and full = true
            {
                hearts[i].sprite = fullHeart;
            }
            else if(i < halfHp) 
            {
                hearts[i].sprite = halfHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < 10)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        animator.SetTrigger("Hurt");
        audioSrc.PlayOneShot(hurtSound);
        if (health <= 0f) {
            health = 0f;
            PlayerDie();
        }
    }

    public void PlayerDie()
    {
        diedUI.gameObject.SetActive(true);
        animator.SetBool("isDead", true);
        audioSrc.PlayOneShot(deathSound);
        //StartCoroutine(Respawn());
        Debug.Log("Player Die");
    }

    public void Respawn()
    {
        //yield return new WaitForSeconds(1f);
        
        FindObjectOfType<LevelManager>().Respawn();
        diedUI.gameObject.SetActive(false) ;
    }

    public void heal()
    {
        health += 4;
        audioSrc.PlayOneShot(potionSound);
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
