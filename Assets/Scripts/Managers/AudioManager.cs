using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    
    public List<AudioClip> audioList;

    void Start()
    {
        musicSource.clip = audioList[0];
        musicSource.Play();
    }

    public void PlaySFX(AudioClip sfxClip)
    {
        sfxSource.PlayOneShot(sfxClip);
    }
}
