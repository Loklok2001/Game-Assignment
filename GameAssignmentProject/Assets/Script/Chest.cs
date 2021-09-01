using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chest : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite openSprite, closedSprite;

    private bool isOpen = false;

    [System.Serializable]
    public class ChestItem
    {
        public GameObject obj;
        public int stack = 0;

        public ChestItem(GameObject o, int s = 1)
        {
            obj = o;
            stack = s;
        }
    }
    public List<ChestItem> items = new List<ChestItem>();

    public GameObject chest_UI;
    public Image[] items_images;
    public TextMeshProUGUI[] quantity;

    public void updateChest()
    {
        ToggleChest();
        Update_Chest();
    }

    public void ToggleChest()
    {
        isOpen = !isOpen;
        if (isOpen)
            Open();
        else
            close();
    }

    public void Open()
    {
        isOpen = true;
        spriteRenderer.sprite = openSprite;
        chest_UI.SetActive(isOpen);
    }

    public void close()
    {
        isOpen = false;
        spriteRenderer.sprite = closedSprite;
        chest_UI.SetActive(isOpen);
    }


    void Update_Chest()
    {
        HideAll();
        for (int i = 0; i < items.Count; i++)
        {
            items_images[i].sprite = items[i].obj.GetComponent<SpriteRenderer>().sprite;
            items_images[i].gameObject.SetActive(true);
            quantity[i].text = items[i].stack.ToString();
            quantity[i].gameObject.SetActive(true);
        }
    }

    void HideAll()
    {
        foreach (var i in items_images)
        {
            i.gameObject.SetActive(false);
        }

        foreach (var q in quantity)
        {
            q.gameObject.SetActive(false);
        }
    }

    public void clickitem(int id)
    {
        Debug.Log($"CONSUMED {items[id].obj.tag}, {items[id].stack}");

        FindObjectOfType<InventorySystem>().PickUp(items[id].obj);

        items[id].stack--;

        //items[id].obj.GetComponent<item>()
        if (items[id].stack == 0)
        {

            items.RemoveAt(id);
        }

        Update_Chest();
    }

}
