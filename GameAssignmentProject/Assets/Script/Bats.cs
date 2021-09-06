using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bats : MonoBehaviour
{
    public float moveSpeed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, moveSpeed * Time.deltaTime);
        }    
        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            string name = gameObject.name.Substring(0, 3);

            if (name == "Bat")
            {
                FindObjectOfType<Bat_Sound>().Bat_hit_sound();
            }

            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
        //Flip the enemy
        if (player.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
