using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBtn : MonoBehaviour
{
    public GameObject teleportPointShow;
    public Text clickDisplay;
    public int clicks;

    public void Click()
    {
        if (InventorySystem.sampleQuantity >= 1)
        {
            FindObjectOfType<InventorySystem>().usesample(1);
            clicks++;
            clickDisplay.text = clicks + " Samples";

            AchievementManager.achievementManagerInstance.AddAchievementProgress("Rabies1", 1);   // the TUT... is the ID of the particular info
            AchievementManager.achievementManagerInstance.AddAchievementProgress("Rabies2", 1);
            AchievementManager.achievementManagerInstance.AddAchievementProgress("Rabies3", 1);
            AchievementManager.achievementManagerInstance.AddAchievementProgress("Rabies4", 1);
            AchievementManager.achievementManagerInstance.AddAchievementProgress("Rabies5", 1);
            AchievementManager.achievementManagerInstance.AddAchievementProgress("Influ1", 1);
            AchievementManager.achievementManagerInstance.AddAchievementProgress("Influ2", 1);
            AchievementManager.achievementManagerInstance.AddAchievementProgress("Influ3", 1);
            AchievementManager.achievementManagerInstance.AddAchievementProgress("Influ4", 1);
            AchievementManager.achievementManagerInstance.AddAchievementProgress("Influ5", 1);


        }

        if (clicks >= 15)
        {
            teleportPointShow.gameObject.SetActive(true);
        }
    }
}
