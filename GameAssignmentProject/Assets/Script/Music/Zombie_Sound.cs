using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Sound : MonoBehaviour
{
    public AudioClip zombie_hited;
    public AudioClip zombie_Die;
    public AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void Zombie_died_sound()
    {
        audioSrc.PlayOneShot(zombie_Die);
    }

    public void Zombie_hited_sound()
    {
        audioSrc.PlayOneShot(zombie_hited);
    }

}
