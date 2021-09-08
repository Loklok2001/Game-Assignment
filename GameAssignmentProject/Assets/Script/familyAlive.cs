using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class familyAlive : MonoBehaviour
{
    public GameObject alive1;
    public GameObject alive2;
    public GameObject alive3;

    int x;

    // Update is called once per frame
    void Update()
    {
        x = NPCHealth.star;
        switch (x)
        {
            case 1:
                alive1.SetActive(true);
                break;
            case 2:
                alive2.SetActive(true);
                break;
            case 3:
                alive3.SetActive(true);
                break;
            default:
                break;
        }
    }
}
