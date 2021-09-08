using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockChapter2 : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<MainMenu>().Save();
    }
}
