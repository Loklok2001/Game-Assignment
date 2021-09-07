using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Sound : MonoBehaviour
{
    public AudioClip bossHit;
    public AudioClip bossDie;
    public AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void Boss_died_sound()
    {
        audioSrc.PlayOneShot(bossDie);
    }

    public void Boss_hited_sound()
    {
        audioSrc.PlayOneShot(bossHit);
    }
}
