using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHotzone : MonoBehaviour
{
    private Wolfs enemyParent;
    private bool inRange;
    private Animator animator;

    private void Awake()
    {
        enemyParent = GetComponentInParent<Wolfs>();
        animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (inRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("WolfAttackRight"))
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
