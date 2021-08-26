using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    Vector2 playerInitPosition;

    void Start()
    {
        playerInitPosition = FindObjectOfType<PlayerController>().transform.position;
    }


    // Update is called once per frame
    public void Respawn() 
    {
        FindObjectOfType<PlayerController>().transform.position = playerInitPosition;
        FindObjectOfType<Healths>().Start();
    }
}
