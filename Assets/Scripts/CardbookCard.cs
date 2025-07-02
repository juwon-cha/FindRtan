using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class CardbookCard : MonoBehaviour
{
    public int index = 0;
    public SpriteRenderer Image;
    AudioSource audioSource;
    public AudioClip clip;

    private CardbookPanel cardbookPanel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
        cardbookPanel = GameObject.Find("CardbookPanel").GetComponent<CardbookPanel>();
    }

    public void Setting(int number)
    {
        index = number;
        Image.sprite = Resources.Load<Sprite>($"CardbookImages/card{index}");
    }

    void OnMouseDown()
    {
        audioSource.PlayOneShot(clip);
        Debug.Log("��ġ");
        if (cardbookPanel != null)
        {
            cardbookPanel.SetCard(Image.sprite, index);  // index�� ���� ����
        }
    }
}
