using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;

    void Start()
    {
        float defaultVolume = 0.5f;

        /*// 슬라이더 초기화
        bgmSlider.value = defaultVolume;
        sfxSlider.value = defaultVolume;

        // 실제 오디오 시스템에도 반영
        AudioManager.Instance.SetBGMVolume(defaultVolume);
        SoundManager.Instance.sfxVolume = defaultVolume;

        // 슬라이더 이벤트 연결
        bgmSlider.onValueChanged.AddListener(OnBGMVolumeChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);*/

        // 저장된 값 불러오기 (없으면 기본값 사용)
        float savedBGM = PlayerPrefs.GetFloat("BGMVolume", defaultVolume);
        float savedSFX = PlayerPrefs.GetFloat("SFXVolume", defaultVolume);

        // 슬라이더 값 초기화
        bgmSlider.value = savedBGM;
        sfxSlider.value = savedSFX;

        // 실제 오디오 시스템에 반영
        AudioManager.Instance.SetBGMVolume(savedBGM);
        SoundManager.Instance.sfxVolume = savedSFX;

        // 슬라이더에 이벤트 연결
        bgmSlider.onValueChanged.AddListener(OnBGMVolumeChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
    }

    void OnBGMVolumeChanged(float value)
    {
        AudioManager.Instance.SetBGMVolume(value);
        PlayerPrefs.SetFloat("BGMVolume", value);
    }

    void OnSFXVolumeChanged(float value)
    {
        SoundManager.Instance.sfxVolume = value;
        PlayerPrefs.SetFloat("SFXVolume", value);
    }
}
