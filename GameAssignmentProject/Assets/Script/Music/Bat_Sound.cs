using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Sound : MonoBehaviour
{
    public AudioClip bat_hited;
    public AudioClip bat_Die;
    public AudioClip bat_hit;
    public AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void Bat_died_sound()
    {
        audioSrc.PlayOneShot(bat_Die);
    }

    public void Bat_hited_sound()
    {
        Debug.Log("aa");
        audioSrc.PlayOneShot(bat_hited);
    }

    public void Bat_hit_sound()
    {
        audioSrc.PlayOneShot(bat_hit);
    }
}
