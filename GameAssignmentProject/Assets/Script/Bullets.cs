using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public int bulletDamage = 10;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealths>().TakeDamage(bulletDamage);
        }
        Destroy(this.gameObject);
    }
}
