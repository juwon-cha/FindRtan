using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject front;
    public GameObject back;

    public Animator anim;

    public SpriteRenderer frontImage;

    AudioSource audioSource;
    public AudioClip clip;

    public int index = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

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

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }

    public void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false); // 애니메이션 CardIdle로 전환
        front.SetActive(false);
        back.SetActive(true);
    }

    public void OnClickCard()
    {
        audioSource.PlayOneShot(clip);
        if (GameManager.Instance.secondCard != null)
        {
            return;
        }

        // SoundManager를 통해 SFX 볼륨 조절
        //audioSource.PlayOneShot(clip, SoundManager.Instance.sfxVolume);

        anim.SetBool("isOpen", true); // 애니메이션 CardFlip으로 전환
        front.SetActive(true);
        back.SetActive(false);

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
        front.SetActive(true);
        back.SetActive(false);
    }
    public void ClosingCard()
    {
        front.SetActive(false);
        back.SetActive(true);
    }
    public void Sharingan()
    {
            OpenCard();
            Invoke("ClosingCard", 3f);
            
    }

    // 저쩔튜터 효과를 위해 애니메이션 없이 즉시 앞면을 보여주는 함수
    public void ForceOpen()
    {
        // 이미 열려있거나 파괴 과정에 있다면 실행하지 않음
        if (anim.GetBool("isOpen"))
        {
            return;
        }

        front.SetActive(true);
        back.SetActive(false);
    }
}
