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
    public float speed = 2;
    private float attackDamage = 20;
    private float attackSpeed = 1f;
    private float canAttack;
    bool isAttacking;

    private void Reset()
    {
        Init();
    }

    void Init()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;

        //Create Root Object
        GameObject root = new GameObject(name + "_Root");

        //Reset Position of Root to enemy object
        root.transform.position = transform.position;

        //Set enemy object as child of root
        transform.SetParent(root.transform);

        //Create Waypoinys Object
        GameObject waypoints = new GameObject("Waypoints");

        //Reset waypoints Position to Root
        //Make waypoints object child of root
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        //Crreate two points (GameObject) and reset their position to waypoints objects
        //Make the points children of waypoint object
        GameObject p1 = new GameObject("Point1"); 
        p1.transform.SetParent(waypoints.transform);
        p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2"); 
        p2.transform.SetParent(waypoints.transform);
        p2.transform.position = root.transform.position;

        //Init points list then add the point to it
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);   
    }

    private void Update()
    {
        animator.SetBool("Attack", isAttacking);
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isAttacking = false;
        if (collision.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                collision.gameObject.GetComponent<Healths>().TakeDamage(attackDamage);
                canAttack = 0f;
                isAttacking = true;
            }
            else 
            {
                canAttack += Time.deltaTime;
            }
        }
        else
            MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
            //Get the next Point Transform
            Transform goalPoint = points[nextID];
            //Flip the enemy
            if (goalPoint.transform.position.x > transform.position.x)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(-1, 1, 1);
            //Move the enemy toward the point
            transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        //Check the distance 
        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            //Check if end
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            //Check if start
            if (nextID == 0)
                idChangeValue = 1;
            nextID += idChangeValue;
        }
    }
}
