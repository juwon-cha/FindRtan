using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Range(0, 1)]
    //public float sfxVolume = 1f;
    public float sfxVolume = 0.5f; // 전체 효과음 슬라이더 값

    // 각 특수카드의 기본 음량 (슬라이더에 곱해질 값)
    public float shariBase = 1f;
    public float goldBase = 0.8f;
    public float sandBase = 1f;
    public float managerBase = 0.7f;
    public float tutoBase = 0.6f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // 기본 sfx볼륨 절반으로 설정
            //sfxVolume = 0.5f;
            sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

