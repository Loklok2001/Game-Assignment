using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickUp : MonoBehaviour
{
    public List<GameObject> itemPick;
    public bool IsitemStore = false;

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Player"))
        {
            itemPick.Add(gameObject);
            FindObjectOfType<InventorySystem>().PickUp(gameObject);
        }
    }
}
