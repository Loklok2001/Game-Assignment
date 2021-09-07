using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNPCUI : MonoBehaviour
{
    public GameObject npc_window;
    bool isOpen = false;

    public void UpdateNPC()
    {
          ToggleNPC();
    }

    public void ToggleNPC()
    {
        isOpen = !isOpen;
        npc_window.SetActive(isOpen);
    }

    public void closeNPC()
    {
        isOpen = false;
        npc_window.SetActive(isOpen);
    }

    public void clickButton()
    {
        FindObjectOfType<InventorySystem>().usevaccine(1);


    }
}
