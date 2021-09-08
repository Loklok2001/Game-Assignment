using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 5f;
    public GameObject Text;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Text.SetActive(false);
            LoadNextScene();
        }
        
    }

    public void LoadNextScene()
    {
       StartCoroutine(LoadLvl(SceneManager.GetActiveScene().buildIndex + 1));
        
    }


    IEnumerator LoadLvl(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
