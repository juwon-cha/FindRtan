using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // 카드를 눌렀을 때 firstCard에 정보 저장
    // 두 번째로 열리는 카드는 firstCard에 정보가 있는지 확인 후
    // firstCard가 있으면 secondCard에도 정보 저장 -> CheckMatched() 실행
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
        Screen.SetResolution(720, 1280, true);

        Time.timeScale = 1f;

        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        time += Time.deltaTime;

        timeTxt.text = time.ToString("N2");

        if (time >= 30f)
        {
            GameOver();
        }
    }

    public void CheckMatched()
    {
        if(firstCard.index == secondCard.index)
        {
            audioSource.PlayOneShot(clip);

            firstCard.DestroyCard();
            secondCard.DestroyCard();

            cardCount -= 2;

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

    void GameOver()
    {
        endTxt.SetActive(true);
        Time.timeScale = 0f;
    }
}
