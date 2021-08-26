using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickUp : MonoBehaviour
{
    

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject item = gameObject;
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<InventorySystem>().PickUp(gameObject);
            gameObject.SetActive(false);
        }

    }
}
