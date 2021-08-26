using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDrop : MonoBehaviour
{
    public GameObject ItemModel;
    public Transform enemydie;

    public void DropItems()
    {
        enemydie = GetComponent<Transform>().transform;
        GameObject item = Instantiate(ItemModel, enemydie.position, Quaternion.identity);
    }
}
