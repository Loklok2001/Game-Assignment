using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyUI : MonoBehaviour
{
    public GameObject story_window;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void closeStory()
    {
        Time.timeScale = 1f;
        story_window.SetActive(false);
    }
}
