using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfArea : MonoBehaviour
{
    private Wolfs enemyParent;

    private void Awake()
    {
        enemyParent = GetComponentInParent<Wolfs>();
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
