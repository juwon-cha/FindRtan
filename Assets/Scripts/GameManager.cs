using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
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
    public AudioClip Shaclip;
    public AudioClip Golclip;
    public AudioClip Sanclip;
    public AudioClip Maclip;
    public AudioClip Tuclip;
    public AudioClip warningClip;

    public int cardCount = 0;
    public int Level = 0;
    float time = 0.0f;

    private Color originalColor;
    private bool isUrgent = false;

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

        if (!isUrgent && time >= 10f)
        {
            isUrgent = true;

            // 경고음 재생
            AudioSource.PlayClipAtPoint(warningClip, Camera.main.transform.position, SoundManager.Instance.sfxVolume);

            // BGM 배속
            AudioManager.Instance.SetPitch(1.5f); // 1.5배속
        }

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
            else if(firstCard.index == 16)
            {
                GoldenRtan();
            }
            else if(firstCard.index == 17)
            {
                Sandevistan();
            }
            else if(firstCard.index == 18)
            {
                StartCoroutine(Manager());
            }
            else if(firstCard.index == 19)
            {
                ActivateJeojjulTutor();
            }

            if (cardCount == 0)
            {
                //GameOver();
                if (Level == 1)
                {
                    EasyClear();
                }
                else if (Level == 2)
                {
                    NormalClear();
                }
                else
                {
                    GameOver();
                }
                
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
        AudioManager.Instance.SetPitch(1f);
        endTxt.SetActive(true);
        Time.timeScale = 0f;
    }
    void GoldenRtan()
    {
        audioSource.PlayOneShot(Golclip);
        Camera.main.backgroundColor = new Color(166f, 124f, 0f, 1f);
        time = time - 5f;
        Invoke("ResetBackground", 1f);
    }
    public void InvokeSharingan()
    {
        audioSource.PlayOneShot(Shaclip);
        Camera.main.backgroundColor = Color.red;
        foreach (Card card in FindObjectsOfType<Card>())
        {
            card.Sharingan();
            Invoke("ResetBackground", 3f);
        }
    }
    void Sandevistan()
    {
        audioSource.PlayOneShot(Sanclip);
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
        audioSource.PlayOneShot(Maclip);
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

    public void ActivateJeojjulTutor()
    {
        audioSource.PlayOneShot(Tuclip);
        // 씬에 있는 모든 Card 컴포넌트를 가져옴
        Card[] allCards = FindObjectsOfType<Card>();

        // 인덱스를 키로, 카드 리스트를 값으로 하는 딕셔너리 생성
        Dictionary<int, List<Card>> cardsByIndex = new Dictionary<int, List<Card>>();

        // 모든 카드를 순회하며 딕셔너리에 추가
        // 인덱스별로 카드 두 장씩 들어감
        foreach (Card card in allCards)
        {
            if (!cardsByIndex.ContainsKey(card.index))
            {
                cardsByIndex[card.index] = new List<Card>();
            }
            cardsByIndex[card.index].Add(card);
        }

        // 아직 맞춰지지 않은 완전한 쌍의 인덱스만 리스트에 저장
        List<int> validPairKeys = new List<int>();
        foreach (var pair in cardsByIndex)
        {
            if (pair.Value.Count == 2)
            {
                validPairKeys.Add(pair.Key);
            }
        }

        // 보여줄 쌍이 있다면
        if (validPairKeys.Count > 0)
        {
            // 유효한 인덱스 리스트에서 무작위로 하나를 선택
            int randomKey = validPairKeys[Random.Range(0, validPairKeys.Count)];

            // 선택된 인덱스를 사용해 원래 딕셔너리에서 카드 쌍을 가져옴
            List<Card> pairToShow = cardsByIndex[randomKey];

            // 카드 쌍 공개 코루틴 실행
            StartCoroutine(RevealPairCoroutine(pairToShow[0], pairToShow[1]));
        }
    }

    private IEnumerator RevealPairCoroutine(Card card1, Card card2)
    {
        // 카드를 즉시 앞면으로 뒤집기
        card1.ForceOpen();
        card2.ForceOpen();

        // 1초 동안 보여줌
        yield return new WaitForSeconds(1f);

        // 다시 뒷면으로 뒤집음
        card1.CloseCardInvoke();
        card2.CloseCardInvoke();
    }
    public void EasyClear()
    {
        GameOver();
        DifficultyButtonManager.isEasyCleared = true;
    }
    public void NormalClear()
    {
        GameOver();
        DifficultyButtonManager.isNormalCleared = true;
    }
}
