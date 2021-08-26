using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    item itemsc;
    public TextMeshProUGUI[] quantity;
    public class InventoryItem
    {
        public GameObject obj;
        public int stack = 1;

        public InventoryItem(GameObject o, int s = 1)
        {
            obj = o;
            stack = s;
        }
    }


    public List<InventoryItem> items = new List<InventoryItem>();

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


    public void PickUp(GameObject item_list)
    {
        if (item_list.GetComponent<item>().IsStackable())
        {
            InventoryItem existing = items.Find(x => x.obj.tag == item_list.tag);

            if(existing!= null)
            {
                existing.stack++;
            }
            else
            {
                InventoryItem i = new InventoryItem(item_list);
                items.Add(i);
            }
        }
        else
        {
            InventoryItem i = new InventoryItem(item_list);
            items.Add(i);
        }
        
        Update_Inventory();
    }

    void Update_Inventory()
    {
        HideAll();
        for(int i =0; i < items.Count; i++)
        {
            items_images[i].sprite = items[i].obj.GetComponent<SpriteRenderer>().sprite;
            items_images[i].gameObject.SetActive(true);
            quantity[i].text = items[i].stack.ToString();
        }
    }

    void HideAll()
    {
        foreach (var i in items_images) { 
            i.gameObject.SetActive(false); 
        }
    }

}
