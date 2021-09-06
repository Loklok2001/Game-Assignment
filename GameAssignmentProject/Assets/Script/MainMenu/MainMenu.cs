using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    int Saved_scene;
    public int Scene_index;
    public int islock = 0;
    public GameObject lockButton;
    public GameObject unlockButton;

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void Chapter1()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Chapter2()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void unlock()
    {
        Scene_index = PlayerPrefs.GetInt("Saved");

        if (Scene_index == 2 || islock == 1)
        {
            unlockButton.SetActive(true);
            lockButton.SetActive(false);
        }
        else
        {
            unlockButton.SetActive(false);
            lockButton.SetActive(true);
        }
    }

    public void Save_and_Exit()
    {
        PauseMenu.GameIsPause = false;
        Time.timeScale = 1f;
        Scene_index = SceneManager.GetActiveScene().buildIndex;
        //Scene_index = PlayerPrefs.GetInt("Saved");
        //if (Scene_index == 2)
        //{
        //    PlayerPrefs.SetInt("islock", 1);
        //    PlayerPrefs.Save();
        //}

        PlayerPrefs.SetInt("Saved", Scene_index);
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(0);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
