using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Sound : MonoBehaviour
{
    public AudioClip Chest_open;
    public AudioClip Chest_close;
    static AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void Chest_open_sound()
    {
        audioSrc.PlayOneShot(Chest_open);
    }

    public void Chest_close_sound()
    {
        audioSrc.PlayOneShot(Chest_close);
    }
}
