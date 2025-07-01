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

    private Color originalColor;

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

        originalColor = Camera.main.backgroundColor;
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

            if(firstCard.index == 15)
            {
                InvokeSharingan();
            }

            if(firstCard.index == 16)
            {
                GoldenRtan();
            }
            if(firstCard.index == 17)
            {
                Sandevistan();
            }
            if(firstCard.index == 18)
            {
                StartCoroutine(Manager());
            }

            if (cardCount == 0)
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
    // 일시정지
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
        Camera.main.backgroundColor = new Color(166f, 124f, 0f, 1f);
        time = time - 5f;
        Invoke("ResetBackground", 1f);
    }
    public void InvokeSharingan()
    {
        Camera.main.backgroundColor = Color.red;
        foreach (Card card in FindObjectsOfType<Card>())
        {
            card.Sharingan();
            Invoke("ResetBackground", 3f);
        }
    }
    void Sandevistan()
    {
        Time.timeScale = 0.4f;
        Camera.main.backgroundColor = Color.yellow;
        Invoke("ResetTimeScale",3f);
        Invoke("ResetBackground", 3f);
    }
    void ResetTimeScale()
    {
        Time.timeScale = 1f;
    }
    IEnumerator Manager()
    {
        Time.timeScale = 0;
        Camera.main.backgroundColor = new Color(107f, 108f, 108f, 1f);
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1;
        Invoke("ResetBackground", 3f);
    }
    public void ResetBackground()
    {
        Camera.main.backgroundColor = originalColor;
    }
}
