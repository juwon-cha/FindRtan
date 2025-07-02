using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public enum ESpecialCard
{
    SHARINGAN = 15,
    GOLDENRTAN,
    SANDEVISTAN,
    AJJULMANAGER,
    JEOJJULTUTOR
}

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
    public AudioClip failclip;
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
    private bool isTimePaused = false;
    private bool isGameOver = false;

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
        // isTimePaused�� false�� ���� �ð� ���
        if(!isTimePaused)
        {
            time += Time.deltaTime;
        }

        timeTxt.text = time.ToString("N2");
        if (time > 60)
        {
            timeTxt.text = "60.00";
        }

        if (!isUrgent && time >= 10f)
        {
            isUrgent = true;

            // ����� ���
            AudioSource.PlayClipAtPoint(warningClip, Camera.main.transform.position, SoundManager.Instance.sfxVolume);

            // BGM ���
            AudioManager.Instance.SetPitch(1.5f); // 1.5���
        }

        if(time >= 30f) // 30�ʳ������� ���������� ���ϰ� �ϱ�
        {
            timeTxt.color = Color.red;
        }

        if (time >= 60f)
        {
            GameOver();
        }
    }

    public void CheckMatched()
    {
        if(firstCard.index == secondCard.index)
        {
            audioSource.PlayOneShot(clip, SoundManager.Instance.sfxVolume);

            firstCard.DestroyCard();
            secondCard.DestroyCard();

            cardCount -= 2;

            if(firstCard.index == (int)ESpecialCard.SHARINGAN)
            {
                InvokeSharingan();
            }
            else if(firstCard.index == (int)ESpecialCard.GOLDENRTAN)
            {
                GoldenRtan();
            }
            else if(firstCard.index == (int)ESpecialCard.SANDEVISTAN)
            {
                Sandevistan();
            }
            else if(firstCard.index == (int)ESpecialCard.AJJULMANAGER)
            {
                StartCoroutine(Manager());
            }
            else if(firstCard.index == (int)ESpecialCard.JEOJJULTUTOR)
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
            audioSource.PlayOneShot(failclip, SoundManager.Instance.sfxVolume);
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }
    // �Ͻ�����
    public void OnPauseButtonPressed()
    {
        isTimePaused = true;
    }

    public void OnResumeButtonPressed()
    {
        if(isGameOver)
        {
            isTimePaused = true;
        }

        isTimePaused = false;
    }

    void GameOver()
    {
        AudioManager.Instance.SetPitch(1f);
        endTxt.SetActive(true);

        isTimePaused = true;
        isGameOver = true;
    }

    void GoldenRtan()
    {
        float volume = SoundManager.Instance.goldBase * SoundManager.Instance.sfxVolume;
        audioSource.PlayOneShot(Golclip, volume);
        Camera.main.backgroundColor = new Color(166f, 124f, 0f, 1f);

        // ���� ���� �� 5�� �̳��� ��� ��ź�� ã���� �� �ð��� ������ �Ǵ� ���� ó��
        if(time > 5f)
        {
            time = time - 5f;
        }
        else
        {
            time = 0f;
        }
        
        Invoke("ResetBackground", 1f);
    }

    public void InvokeSharingan()
    {
        float volume = SoundManager.Instance.shariBase * SoundManager.Instance.sfxVolume;
        audioSource.PlayOneShot(Shaclip, volume);
        Camera.main.backgroundColor = Color.red;
        foreach (Card card in FindObjectsOfType<Card>())
        {
            card.Sharingan();
            Invoke("ResetBackground", 3f);
        }
    }

    void Sandevistan()
    {
        float volume = SoundManager.Instance.sandBase * SoundManager.Instance.sfxVolume;
        audioSource.PlayOneShot(Sanclip, volume);
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
        float volume = SoundManager.Instance.managerBase * SoundManager.Instance.sfxVolume;
        audioSource.PlayOneShot(Maclip, volume);
        Camera.main.backgroundColor = new Color(107f, 108f, 108f, 1f);

        isTimePaused = true;
        yield return new WaitForSecondsRealtime(5f);
        isTimePaused = false;

        Invoke("ResetBackground", 3f);
    }

    public void ResetBackground()
    {
        Camera.main.backgroundColor = originalColor;
    }

    public void ActivateJeojjulTutor()
    {
        float volume = SoundManager.Instance.tutoBase * SoundManager.Instance.sfxVolume;
        audioSource.PlayOneShot(Tuclip, volume);
        // ���� �ִ� ��� Card ������Ʈ�� ������
        Card[] allCards = FindObjectsOfType<Card>();

        // �ε����� Ű��, ī�� ����Ʈ�� ������ �ϴ� ��ųʸ� ����
        Dictionary<int, List<Card>> cardsByIndex = new Dictionary<int, List<Card>>();

        // ��� ī�带 ��ȸ�ϸ� ��ųʸ��� �߰�
        // �ε������� ī�� �� �徿 ��
        foreach (Card card in allCards)
        {
            // Ʃ�� Ư�� ī��� ���� -> Ʃ�� ī�尡 ������鼭 �ڽ��� ã���� ����
            if(card.index != (int)ESpecialCard.JEOJJULTUTOR)
            {
                if (!cardsByIndex.ContainsKey(card.index))
                {
                    cardsByIndex[card.index] = new List<Card>();
                }
                cardsByIndex[card.index].Add(card);
            }
        }

        // ���� �������� ���� ������ ���� �ε����� ����Ʈ�� ����
        List<int> validPairKeys = new List<int>();
        foreach (var pair in cardsByIndex)
        {
            if (pair.Value.Count == 2)
            {
                validPairKeys.Add(pair.Key);
            }
        }

        // ������ ���� �ִٸ�
        if (validPairKeys.Count > 0)
        {
            // ��ȿ�� �ε��� ����Ʈ���� �������� �ϳ��� ����
            int randomKey = validPairKeys[Random.Range(0, validPairKeys.Count)];

            // ���õ� �ε����� ����� ���� ��ųʸ����� ī�� ���� ������
            List<Card> pairToShow = cardsByIndex[randomKey];

            // ī�� �� ���� �ڷ�ƾ ����
            StartCoroutine(RevealPairCoroutine(pairToShow[0], pairToShow[1]));
        }
    }

    private IEnumerator RevealPairCoroutine(Card card1, Card card2)
    {
        // ī�带 ��� �ո����� ������
        card1.OpenCard();
        card2.OpenCard();

        // 1�� ���� ������
        yield return new WaitForSeconds(1f);

        // �ٽ� �޸����� ������
        card1.CloseCard();
        card2.CloseCard();
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

    public void ResetTimerColor() //����۽� Ÿ���� �÷��� �����ϱ� ����
    {
        timeTxt.color = originalColor;
    }
}
