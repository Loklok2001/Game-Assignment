using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();

    public GameObject ui_window;
    public Image[] items_images;

    public GameObject ui_Description_window;
    public Image decription_Image;
    public Text decription_Text;

    public void PickUp(GameObject item)
    {
        items.Add(item);
    }



}
