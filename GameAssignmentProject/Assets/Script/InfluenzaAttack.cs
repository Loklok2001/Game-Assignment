using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenzaAttack : MonoBehaviour
{
    public int attackDamage = 3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Healths>().TakeDamage(attackDamage);
        }
    }
}
