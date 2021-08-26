using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    bool isOpen = false;

    public GameObject ui_window;
    public Image[] items_images;

    public GameObject ui_Description_window;
    public Image decription_Image;
    public Text decription_Text;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isOpen = !isOpen;
        ui_window.SetActive(isOpen);
    }

    public void PickUp(GameObject item)
    {
        items.Add(item);
        Update_Inventory();
    }

    void Update_Inventory()
    {
        HideAll();
        for(int i =0; i < items.Count; i++)
        {
            items_images[i].sprite = items[i].GetComponent<SpriteRenderer>().sprite;
            items_images[i].gameObject.SetActive(true);
        }
    }

    void HideAll()
    {
        foreach (var i in items_images) { 
            i.gameObject.SetActive(false); 
        }
    }

}
