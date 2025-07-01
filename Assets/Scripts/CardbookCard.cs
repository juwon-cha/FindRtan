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

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setting(int number)
    {
        index = number;
        Image.sprite = Resources.Load<Sprite>($"CardbookImages/card{index}");
    }

    public void OnClickCard()
    {
        audioSource.PlayOneShot(clip);
    }
}
