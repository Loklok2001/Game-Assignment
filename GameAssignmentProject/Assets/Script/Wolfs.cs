using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Wolfs : MonoBehaviour
{
    public Animator animator;
    public List<Transform> points;

    public int nextID = 0;
    int idChangeValue = 1;
    private float speed = 2;
    private float attackDamage = 20;
    private float attackSpeed = 2.5f;
    private float canAttack;
    bool isAttacking;

    private void FixedUpdate()
    {
        speed = 2;
        //MoveToNextPoint();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            speed = 0;
            isAttacking = true;
            if (attackSpeed <= canAttack)
            {
                collision.gameObject.GetComponent<Healths>().TakeDamage(attackDamage);
                animator.SetTrigger("Attack");
                canAttack = 0f;
            }
            else 
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    //void MoveToNextPoint()
    //{
    //        //Get the next Point Transform
    //        Transform goalPoint = points[nextID];
    //        //Flip the enemy
    //        if (goalPoint.transform.position.x > transform.position.x)
    //            transform.localScale = new Vector3(1, 1, 1);
    //        else
    //            transform.localScale = new Vector3(-1, 1, 1);
    //        //Move the enemy toward the point
    //        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
    //        //Check the distance 
    //        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
    //        {
    //            //Check if end
    //            if (nextID == points.Count - 1)
    //                idChangeValue = -1;
    //            //Check if start
    //            if (nextID == 0)
    //                idChangeValue = 1;
    //            nextID += idChangeValue;
    //        }
    //    }
}
