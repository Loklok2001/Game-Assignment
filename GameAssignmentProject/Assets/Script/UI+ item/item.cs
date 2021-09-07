using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public enum ItemType
    {
        potion,
        paper,
        bullet,
        enxyclopedia,
        vaccine
    }

    public ItemType itemtype;
    public string itemdescripion;

    public Sprite GetSprite()
    {
        switch (itemtype)
        {
            default:
            case ItemType.paper:    
                return itemAssets.Instance.paperSprite;
            case ItemType.potion:
                return itemAssets.Instance.potionSprite;
            case ItemType.bullet:
                return itemAssets.Instance.bulletSprite;
            case ItemType.enxyclopedia:
                return itemAssets.Instance.enxyclopediaSprite;
        }
    }

    public bool IsStackable()
    {
        switch (itemtype)
        {
            default:
            case ItemType.potion:
            case ItemType.paper:
            case ItemType.vaccine:
                return true;
            case ItemType.enxyclopedia:
                return false;
        }
    }

    public bool consumeitem()
    {
        switch (itemtype)
        {
            default:
                return true;
            case ItemType.enxyclopedia:
            case ItemType.potion:
            case ItemType.paper:
            case ItemType.vaccine:
                return false;
        }
    }

    public void consume(string itemtag)
    {
        switch (itemtag)
        {
            case "potion":
                FindObjectOfType<Healths>().heal();
                break;
            default:
                break;
        }

    }
}
