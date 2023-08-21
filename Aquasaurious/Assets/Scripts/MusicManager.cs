using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip[] audioClips;

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();

    }

    void Update() {
        if(!audioSource.isPlaying) {
            audioSource.clip = getRandomClip();
            audioSource.Play();
        }
    }

    private AudioClip getRandomClip() { return audioClips[Random.Range(0, audioClips.Length)]; }

}
