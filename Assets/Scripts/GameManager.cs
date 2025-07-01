using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // ī�带 ������ �� firstCard�� ���� ����
    // �� ��°�� ������ ī��� firstCard�� ������ �ִ��� Ȯ�� ��
    // firstCard�� ������ secondCard���� ���� ���� -> CheckMatched() ����
    public Card firstCard;
    public Card secondCard;

    public GameObject endTxt;
    public Text timeTxt;

    AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;
    float time = 0.0f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Screen.SetResolution(1920, 1280, true);

        Time.timeScale = 1f;

        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        time += Time.deltaTime;

        timeTxt.text = time.ToString("N2");

        if (time >= 180f)
        {
            GameOver();
        }
    }

    public void CheckMatched()
    {
        if(firstCard.index == secondCard.index)
        {
            //audioSource.PlayOneShot(clip, SoundManager.Instance.sfxVolume);

            firstCard.DestroyCard();
            secondCard.DestroyCard();

            cardCount -= 2;

            if(firstCard.index == 16)
            {
                GoldenRtan();
            }

            if(cardCount == 0)
            {
                GameOver();
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }
    // �Ͻ�����
    public void OnPauseButtonPressed()
    {
        Time.timeScale = 0f;
    }

    public void OnResumeButtonPressed()
    {
        Time.timeScale = 1f;
    }


    void GameOver()
    {
        endTxt.SetActive(true);
        Time.timeScale = 0f;
    }
    void GoldenRtan()
    {
        time = time - 5f;
    }
    void Sharingan()
    {

    }

}
