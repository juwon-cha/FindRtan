using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // ī�� ������ ���� Ease ����
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
        // �̹� �����ְų� �ı� ������ �ִٸ� �������� ����
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

        // ī���� ���� ũ�⸦ 0.2�� ���� 0���� ����� �����ϰ� ����
        seq.Append(transform.DOScale(targetScale, 0.2f).SetEase(ease));
        seq.AppendCallback(() =>
        {
            // ī�尡 ���������� �� ��/�޸��� �ٲ�
            front.SetActive(open);
            back.SetActive(!open);
        });
        // �ٽ� 0.2�� ���� ���� ũ�⸦ 1�� ����� �������� ��
        seq.Append(transform.DOScale(originalScale, 0.2f).SetEase(ease));
    }
}
