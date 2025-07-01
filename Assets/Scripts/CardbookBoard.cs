using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class CardbookBoard : MonoBehaviour
{
    public GameObject card;

    // Start is called before the first frame update
    void Start()
    {
        int[] arr = { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19 };

        for (int i = 0; i < 20; ++i)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 5) * 1.6f - 7.5f;
            float y = (i / 5) * 1.6f - 1.2f;

            go.transform.position = new Vector2(x, y);

            // 카드 인덱스 설정
            go.GetComponent<CardbookCard>().Setting(arr[i]);
        }

        //GameManager.Instance.cardCount = arr.Length;
    }
}

 
