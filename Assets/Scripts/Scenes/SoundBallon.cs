using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBallon : MonoBehaviour
{
    public static SoundBallon Instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundBallon(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
