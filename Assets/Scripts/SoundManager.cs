using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Range(0, 1)]
    public float sfxVolume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // �⺻ sfx���� �������� ����
            sfxVolume = 0.5f;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

