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

        /*// �����̴� �ʱ�ȭ
        bgmSlider.value = defaultVolume;
        sfxSlider.value = defaultVolume;

        // ���� ����� �ý��ۿ��� �ݿ�
        AudioManager.Instance.SetBGMVolume(defaultVolume);
        SoundManager.Instance.sfxVolume = defaultVolume;

        // �����̴� �̺�Ʈ ����
        bgmSlider.onValueChanged.AddListener(OnBGMVolumeChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);*/

        // ����� �� �ҷ����� (������ �⺻�� ���)
        float savedBGM = PlayerPrefs.GetFloat("BGMVolume", defaultVolume);
        float savedSFX = PlayerPrefs.GetFloat("SFXVolume", defaultVolume);

        // �����̴� �� �ʱ�ȭ
        bgmSlider.value = savedBGM;
        sfxSlider.value = savedSFX;

        // ���� ����� �ý��ۿ� �ݿ�
        AudioManager.Instance.SetBGMVolume(savedBGM);
        SoundManager.Instance.sfxVolume = savedSFX;

        // �����̴��� �̺�Ʈ ����
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
