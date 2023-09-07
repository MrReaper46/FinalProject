using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get => instance; set => instance = value; }

    public AudioSource BGM;
    public AudioSource Press;
    public AudioSource Feed;
    public AudioSource Pet;
    public AudioSource Fail;

    public void PlaySound(AudioSource sfx)
    {
        sfx.Play();
    }
}
