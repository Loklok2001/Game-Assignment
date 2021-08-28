using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    
    public TextMeshProUGUI[] quantity;

    [System.Serializable]
    public class InventoryItem
    {
        public GameObject obj;
        public int stack = 0;

        public InventoryItem(GameObject o, int s = 1)
        {
            obj = o;
            stack = s;
        }
    }
    item itemsc;

    [Header("General fields")]

    public List<InventoryItem> items = new List<InventoryItem>();

    bool isOpen = false;

    public GameObject ui_window;
    public Image[] items_images;
    public Text[] items_Number;

    public GameObject ui_Description_window;
    public Image decription_Image;
    public Text decription_Title;
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
            quantity[i].gameObject.SetActive(true);
        }
        HideDescription();
    }

    void HideAll()
    {
        foreach (var i in items_images) { 
            i.gameObject.SetActive(false); 
        }

        foreach(var q in quantity)
        {
            q.gameObject.SetActive(false);
        }
    }

    public void ShowDescription(int id)
    {
        decription_Image.sprite = items_images[id].sprite;
        decription_Title.text = items[id].obj.name.ToString();
        decription_Text.text = items[id].obj.GetComponent<item>().itemdescripion;

        ui_Description_window.gameObject.SetActive(true);
        decription_Image.gameObject.SetActive(true);
        decription_Title.gameObject.SetActive(true);
        decription_Text.gameObject.SetActive(true);
    }

    public void HideDescription()
    {
        decription_Title.gameObject.SetActive(false);
        decription_Image.gameObject.SetActive(false);
        decription_Text.gameObject.SetActive(false);
    }

    public void useitem(int id)
    {

        Debug.Log($"CONSUMED {items[id].obj.name}, {items[id].stack}");

        items[id].stack--;
        //items[id].obj.GetComponent<item>()
        if (items[id].stack == 0)
        {
            Destroy(items[id].obj, 0.1f);

            items.RemoveAt(id);
        }

        

        Update_Inventory();
        
    }
}
