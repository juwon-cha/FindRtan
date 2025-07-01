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

        // 슬라이더 초기화
        bgmSlider.value = defaultVolume;
        sfxSlider.value = defaultVolume;

        // 실제 오디오 시스템에도 반영
        AudioManager.Instance.SetBGMVolume(defaultVolume);
        SoundManager.Instance.sfxVolume = defaultVolume;

        // 슬라이더 이벤트 연결
        bgmSlider.onValueChanged.AddListener(OnBGMVolumeChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
    }

    void OnBGMVolumeChanged(float value)
    {
        AudioManager.Instance.SetBGMVolume(value);
    }

    void OnSFXVolumeChanged(float value)
    {
        SoundManager.Instance.sfxVolume = value;
    }
}
