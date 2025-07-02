using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Range(0, 1)]
    //public float sfxVolume = 1f;
    public float sfxVolume = 0.5f; // ��ü ȿ���� �����̴� ��

    // �� Ư��ī���� �⺻ ���� (�����̴��� ������ ��)
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

            // �⺻ sfx���� �������� ����
            //sfxVolume = 0.5f;
            sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

