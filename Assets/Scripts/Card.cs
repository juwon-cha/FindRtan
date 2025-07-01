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
        if(GameManager.Instance.secondCard != null)
        {
            return;
        }

        audioSource.PlayOneShot(clip);

        anim.SetBool("isOpen", true); // 애니메이션 CardFlip으로 전환
        front.SetActive(true);
        back.SetActive(false);

        // firstCard가 비어있다면,
        if(GameManager.Instance.firstCard == null)
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
}
