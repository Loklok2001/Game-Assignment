using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_Sound : MonoBehaviour
{
    public AudioClip wolf_hited;
    public AudioClip wolf_Die;
    static AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void Wolf_died_sound()
    {
        audioSrc.PlayOneShot(wolf_Die);
    }

    public void Wolf_hited_sound()
    {
        audioSrc.PlayOneShot(wolf_hited);
    }

}
