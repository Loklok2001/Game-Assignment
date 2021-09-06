using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemAssets : MonoBehaviour
{
    public static itemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite paperSprite;
    public Sprite potionSprite;
    public Sprite bulletSprite;
    public Sprite enxyclopediaSprite;
}
