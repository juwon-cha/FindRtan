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
        anim.SetBool("isOpen", false); // �ִϸ��̼� CardIdle�� ��ȯ
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

        // SoundManager�� ���� SFX ���� ����
        //audioSource.PlayOneShot(clip, SoundManager.Instance.sfxVolume);

        anim.SetBool("isOpen", true); // �ִϸ��̼� CardFlip���� ��ȯ
        front.SetActive(true);
        back.SetActive(false);

        // firstCard�� ����ִٸ�,
        if (GameManager.Instance.firstCard == null)
        {
            // firstCard�� �� ���� ����
            GameManager.Instance.firstCard = this;
        }
        else // firstCard�� ������� �ʴٸ�,
        {
            // secondCard�� �� ���� ����
            GameManager.Instance.secondCard = this;

            // ���ӸŴ����� CheckMatched() �Լ� ȣ��
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

    // ��¿Ʃ�� ȿ���� ���� �ִϸ��̼� ���� ��� �ո��� �����ִ� �Լ�
    public void ForceOpen()
    {
        // �̹� �����ְų� �ı� ������ �ִٸ� �������� ����
        if (anim.GetBool("isOpen"))
        {
            return;
        }

        front.SetActive(true);
        back.SetActive(false);
    }
}
