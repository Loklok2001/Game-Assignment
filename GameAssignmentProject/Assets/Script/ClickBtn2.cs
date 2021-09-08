using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBtn2 : MonoBehaviour
{
    public GameObject teleportPointShow;
    public GameObject vaccine;
    public Text clickDisplay;
    public int clicks;

    public void Click()
    {
        if (InventorySystem.sampleQuantity >= 1)
        {
            FindObjectOfType<InventorySystem>().usesample(1);
            clicks++;
            clickDisplay.text = clicks + " Samples";

            AchievementManager.achievementManagerInstance.AddAchievementProgress("Influ1", 1);
            AchievementManager.achievementManagerInstance.AddAchievementProgress("Influ2", 1);
            AchievementManager.achievementManagerInstance.AddAchievementProgress("Influ3", 1);
            AchievementManager.achievementManagerInstance.AddAchievementProgress("Influ4", 1);
            AchievementManager.achievementManagerInstance.AddAchievementProgress("Influ5", 1);

            if (clicks % 5 == 0)
            {
                FindObjectOfType<InventorySystem>().PickUp(vaccine);
            }
        }

      
    }
}
