using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite openSprite, closedSprite;

    private bool isOpen = false;

    public void updateChest()
    {

        ToggleChest();

    }

    public void ToggleChest()
    {
        isOpen = !isOpen;
        if (isOpen)
            spriteRenderer.sprite = openSprite;
        else
            spriteRenderer.sprite = closedSprite;
    }

    public void Open()
    {
        isOpen = true;
        spriteRenderer.sprite = openSprite;
    }

    public void close()
    {
        isOpen = false;
        spriteRenderer.sprite = closedSprite;
    }
}
