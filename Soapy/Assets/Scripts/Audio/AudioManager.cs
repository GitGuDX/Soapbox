using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip backgroundMusic;
    public AudioClip bubblePopping;
    public AudioClip like;
    public AudioClip dislike;


private void Start()
{
 musicSource.clip = backgroundMusic;
 musicSource.Play();
}

public void PlaySFX(AudioClip clip) {
    sfxSource.PlayOneShot(clip);
}
}
