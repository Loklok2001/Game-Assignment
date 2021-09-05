using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    int Saved_scene;
    int Scene_index;
    public GameObject SavedData;

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Load_saced_scene()
    {
        Saved_scene = PlayerPrefs.GetInt("Saved");

        if (Saved_scene != 0)
            SceneManager.LoadSceneAsync(Saved_scene);
        else
            return;
    }

    public void Save_and_Exit()
    {
        PauseMenu.GameIsPause = false;
        Time.timeScale = 1f;
        Scene_index = SceneManager.GetActiveScene().buildIndex;

        PlayerPrefs.SetInt("Saved", Scene_index);
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(0);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void Next_Scene()
    {
        Scene_index++;
    }
}
