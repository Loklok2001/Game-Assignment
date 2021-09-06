﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBtn : MonoBehaviour
{
    public Text clickDisplay;
    public int clicks;

    public void Click()
    {
        clicks++;
        clickDisplay.text = clicks + " Samples";

        AchievementManager.achievementManagerInstance.AddAchievementProgress("Rabies1", 1);   // the TUT... is the ID of the particular info
        AchievementManager.achievementManagerInstance.AddAchievementProgress("Rabies2", 1);
        AchievementManager.achievementManagerInstance.AddAchievementProgress("Rabies3", 1);
        AchievementManager.achievementManagerInstance.AddAchievementProgress("Rabies4", 1);

    }
}