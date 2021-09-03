using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    bool isOpen = false;
    [SerializeField]
    public GameObject shop_ui_window;
    public GameObject invalid_ui_window;
    public GameObject gameobject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleShop();
        }
    }

    public void ToggleShop()
    {
        isOpen = !isOpen;
        shop_ui_window.SetActive(isOpen);
    }

    public void closeShop()
    {
        isOpen = false;
        shop_ui_window.SetActive(isOpen);
    }

    public void buyItem()
    {
        if(InventorySystem.sampleQuantity >= 2)
        {
            GetComponent<InventorySystem>().PickUp(gameobject);
            GetComponent<InventorySystem>().usesample(2);
        }
        else
        {
            invalid_ui_window.SetActive(true);
        }
    }

    public void CloseInvalidUI()
    {
        invalid_ui_window.SetActive(false);
    }
}
