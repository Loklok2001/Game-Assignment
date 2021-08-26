using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBullet : MonoBehaviour
{
    GameObject target;
    public float bulletSpeed;
    Rigidbody2D bulletRB;
    public float bulletDamage = 2f;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * bulletSpeed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Healths>().TakeDamage(bulletDamage);
            Destroy(this.gameObject);
        }
    }
}

