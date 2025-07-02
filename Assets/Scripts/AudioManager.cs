using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        float savedBGM = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        SetBGMVolume(savedBGM);

        audioSource.clip = clip;
        audioSource.Play();
    }

    public void SetBGMVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void SetPitch(float pitch)
    {
        if (audioSource != null)
        {
            audioSource.pitch = pitch;
        }
    }
}
