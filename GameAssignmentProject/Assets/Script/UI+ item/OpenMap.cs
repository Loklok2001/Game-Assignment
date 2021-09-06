using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMap : MonoBehaviour
{
    public GameObject map_window;
    bool isOpen = false;

    private void Update()
    {
        if (!PauseMenu.GameIsPause)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                ToggleMap();
            }
        }
    }

    public void ToggleMap()
    {
        isOpen = !isOpen;
        map_window.SetActive(isOpen);
    }

    public void closeMap()
    {
        isOpen = false;
        map_window.SetActive(isOpen);
    }
}
