using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabientArea : MonoBehaviour
{
    private Rabients enemyParent;

    private void Awake()
    {
        enemyParent = GetComponentInParent<Rabients>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            enemyParent.target = collision.transform;
            enemyParent.inRange = true;
            enemyParent.hotzone.SetActive(true);
        }
    }
}
