using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PotionCoolDown : MonoBehaviour
{
    public Image potionImage;
    public float cooldown = 5;
    public static bool isCooldown = false;
    public KeyCode potion;

    // Start is called before the first frame update
    void Start()
    {
        potionImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCooldown)
        {
            if (Input.GetButtonDown("potion"))
            {
                FindObjectOfType<InventorySystem>().UsePotion();
            }
        }
        Potioncooldown();
    }

    void Potioncooldown()
    {
        if(Input.GetKey(potion) && isCooldown == false)
        {
            isCooldown = true;
            potionImage.fillAmount = 1;
        }

        if (isCooldown)
        {
            potionImage.fillAmount -= 1 / cooldown * Time.deltaTime;

            if(potionImage.fillAmount <= 0)
            {
                potionImage.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}
