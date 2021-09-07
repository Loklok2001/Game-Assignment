using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionSystemr : MonoBehaviour
{
    public Transform detactionPoint;
    private const float detactionRadius = 0.2f;
    public LayerMask detectionLayer;
    public LayerMask detectionLayer2;

    // Update is called once per frame
    void Update()
    {
        if (DetactNPC())
        {
            if (InteractInput())
            {
                FindObjectOfType<OpenNPCUI>().UpdateNPC();
            }
        }

        if (DetactChest())
        {
            if (openInput())
            {
                FindObjectOfType<Chest>().updateChest();
            }
        }
    }

    bool openInput()
    {
        return Input.GetKeyDown(KeyCode.R);
    }

    bool DetactChest()
    {
        return Physics2D.OverlapCircle(detactionPoint.position, detactionRadius, detectionLayer);
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.N);
    }

    bool DetactNPC()
    {
        return Physics2D.OverlapCircle(detactionPoint.position, detactionRadius, detectionLayer2);
    }


}
