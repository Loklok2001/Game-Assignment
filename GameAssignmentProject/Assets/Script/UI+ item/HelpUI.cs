using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpUI : MonoBehaviour
{
    public GameObject help_window;
    bool isOpen = false;

    private void Update()
    {
        if (!PauseMenu.GameIsPause)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                ToggleHelp();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                closeHelp();
            }
        }
    }

    public void ToggleHelp()
    {
        isOpen = !isOpen;
        help_window.SetActive(isOpen);
    }

    public void closeHelp()
    {
        isOpen = false;
        help_window.SetActive(isOpen);
    }
}
