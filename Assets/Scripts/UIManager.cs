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

        // �����̴� �ʱ�ȭ
        bgmSlider.value = defaultVolume;
        sfxSlider.value = defaultVolume;

        // ���� ����� �ý��ۿ��� �ݿ�
        AudioManager.Instance.SetBGMVolume(defaultVolume);
        SoundManager.Instance.sfxVolume = defaultVolume;

        // �����̴� �̺�Ʈ ����
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
