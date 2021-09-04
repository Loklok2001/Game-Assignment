using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDrop : MonoBehaviour
{
    public GameObject ItemModel;
    public Transform enemydie;

    public void DropItems(GameObject gameobject)
    {
        enemydie = gameobject.transform;
        GameObject item = Instantiate(ItemModel, enemydie.position, Quaternion.identity);
    }
}
