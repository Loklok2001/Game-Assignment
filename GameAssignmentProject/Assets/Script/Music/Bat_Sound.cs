using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Sound : MonoBehaviour
{
    public AudioClip bat_Die;
    static AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void Bat_died_sound()
    {
        Debug.Log("as");
        audioSrc.PlayOneShot(bat_Die);
    }
}
