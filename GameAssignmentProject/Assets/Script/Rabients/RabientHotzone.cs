using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabientHotzone : MonoBehaviour
{
    private Rabients enemyParent;
    private bool inRange;
    private Animator animator;

    private void Awake()
    {
        enemyParent = GetComponentInParent<Rabients>();
        animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (inRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("RabientAttackLeft"))
            enemyParent.Flip();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            gameObject.SetActive(false);
            enemyParent.triggerArea.SetActive(true);
            enemyParent.inRange = false;
            enemyParent.SelectTarget();
        }
    }
}
