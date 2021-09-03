using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHotzone : MonoBehaviour
{
    private BossStage2 enemyParent;
    private bool inRange;
    private Animator animator;

    private void Awake()
    {
        enemyParent = GetComponentInParent<BossStage2>();
        animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (inRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("BossAttack"))
            enemyParent.Flip();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collisions)
    {
        if (collisions.gameObject.CompareTag("Player"))
        {
            enemyParent.triggerArea.SetActive(true);
            Debug.Log("Out");
            inRange = false;
            gameObject.SetActive(false);
            enemyParent.inRange = false;
            enemyParent.SelectTarget();
        }
    }
}

