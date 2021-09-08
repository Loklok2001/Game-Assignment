using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    bool isOpen = false;
    [SerializeField]
    public GameObject shop_ui_window;
    public GameObject invalid_ui_window;
    public GameObject gameobject;
    public TextMeshProUGUI remainQuantity;

    public static int limit;

    private void Start()
    {
        limit = 5;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleShop();
            remainQuantity.text = "Remained :" + limit.ToString();
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
        if(limit > 0)
        {
            if (InventorySystem.sampleQuantity >= 2)
            {
                GetComponent<InventorySystem>().PickUp(gameobject);
                GetComponent<InventorySystem>().usesample(2);
                limit--;
                remainQuantity.text = "Remained :" + limit.ToString();
            }
            else
            {
                invalid_ui_window.SetActive(true);
            }
        }
    }

    public void CloseInvalidUI()
    {
        invalid_ui_window.SetActive(false);
    }
}
