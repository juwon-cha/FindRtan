using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // 카드 뒤집기 연출 Ease 설정
    public Ease ease = Ease.Linear;

    public GameObject front;
    public GameObject back;

    public SpriteRenderer frontImage;

    AudioSource audioSource;
    public AudioClip clip;

    public int index = 0;

    private bool mbIsOpened = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Setting(int number)
    {
        index = number;
        frontImage.sprite = Resources.Load<Sprite>($"Images/Card{index}");
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.5f);
    }

    public void DestroyCardInvoke()
    {

        Destroy(gameObject);
    }

    public void OnClickCard()
    {
        audioSource.PlayOneShot(clip, SoundManager.Instance.sfxVolume);

        if (GameManager.Instance.secondCard != null)
        {
            return;
        }

        OpenCard();

        // firstCard가 비어있다면,
        if (GameManager.Instance.firstCard == null)
        {
            // firstCard에 내 정보 저장
            GameManager.Instance.firstCard = this;
        }
        else // firstCard가 비어있지 않다면,
        {
            // secondCard에 내 정보 저장
            GameManager.Instance.secondCard = this;

            // 게임매니저의 CheckMatched() 함수 호출
            GameManager.Instance.CheckMatched();
        }
    }

    public void OpenCard()
    {
        // 이미 열려있거나 파괴 과정에 있다면 실행하지 않음
        if (mbIsOpened)
        {
            return;
        }

        FlipCard(true);

        mbIsOpened = true;
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }

    public void CloseCardInvoke()
    {
        front.SetActive(false);
        back.SetActive(true);

        mbIsOpened = false;
    }

    public void Sharingan()
    {
        OpenCard();
        Invoke("CloseCard", 3f);
    }

    private void FlipCard(bool open)
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = new Vector3(0f, originalScale.y, originalScale.z);

        var seq = DOTween.Sequence();

        // 카드의 가로 크기를 0.2초 동안 0으로 만들어 납작하게 만듦
        seq.Append(transform.DOScale(targetScale, 0.2f).SetEase(ease));
        seq.AppendCallback(() =>
        {
            // 카드가 납작해졌을 때 앞/뒷면을 바꿈
            front.SetActive(open);
            back.SetActive(!open);
        });
        // 다시 0.2초 동안 가로 크기를 1로 만들어 펼쳐지게 함
        seq.Append(transform.DOScale(originalScale, 0.2f).SetEase(ease));
    }
}
