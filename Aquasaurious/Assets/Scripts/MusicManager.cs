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
            AudioClip ac = GetRandomClip();

            while(ac == audioSource.clip)
                ac = GetRandomClip();

            audioSource.clip = ac;
            audioSource.Play();
        }
    }

    private AudioClip GetRandomClip() { return audioClips[Random.Range(0, audioClips.Length)]; }

}
