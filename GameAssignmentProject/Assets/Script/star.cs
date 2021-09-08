using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class star : MonoBehaviour
{
    public Image starImage;
    public Sprite star0;
    public Sprite star1;
    public Sprite star2;
    public Sprite star3;
    int x;

    // Update is called once per frame
    void Update()
    {
        x = NPCHealth.star;
        switch (x)
        {
            case 0:
                starImage.sprite = star0;
                break;
            case 1:
                starImage.sprite = star1;
                break;
            case 2:
                starImage.sprite = star2;
                break;
            case 3:
                starImage.sprite = star3;
                break;
            default:
                break;
        }
    }
}
