using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowChest : MonoBehaviour
{
    public GameObject chest;

    public void DisplayChest()
    {
        chest.SetActive(true);
    }
}
