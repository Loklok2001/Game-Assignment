using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{


    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Debug.Log("helloo");
        Screen.fullScreen = isFullscreen;
    }
}
