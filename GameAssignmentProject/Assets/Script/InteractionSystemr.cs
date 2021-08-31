using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionSystemr : MonoBehaviour
{
    public Transform detactionPoint;
    private const float detactionRadius = 0.2f;
    public LayerMask detectionLayer;

    // Update is called once per frame
    void Update()
    {
        if (DetactChest())
        {
            if (openInput())
            {
                Debug.Log("halo");
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
}
