using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNPCUI : MonoBehaviour
{
    public Transform detactionPoint;
    private const float detactionRadius = 0.2f;
    public LayerMask detectionLayer;
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
        if (FindObjectOfType<InventorySystem>().usevaccine(1))
        {
            Physics2D.OverlapCircle(detactionPoint.position, detactionRadius, detectionLayer).GetComponent<NPCHealth>().stopcounter();
            npc_window.SetActive(false);
        }
    }
}

