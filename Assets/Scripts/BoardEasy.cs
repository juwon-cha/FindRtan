using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEditor;

public class BoardEasy : MonoBehaviour
{
    public GameObject card;
    void Start()
    {
                // 카드 섞기
                int[] Earr = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14};
                Earr = Earr.Take(5).ToArray();
                Earr = Earr.OrderBy(x => UnityEngine.Random.Range(0f, 14f)).ToArray();
                int[] Espc = {15,16,17,18, 19};
                Espc = Espc.OrderBy(x => UnityEngine.Random.Range(15f, 19f)).ToArray();
                Espc = Espc.Take(1).ToArray();

                int[] Ecom = Earr.Concat(Espc).ToArray();
                int[] Efinaldeck = Ecom.Concat(Ecom).ToArray();
                Shuffle(Efinaldeck);

                // 셔플 디버깅
                //string arrayString = string.Join(", ", arr);
                //Debug.Log(arrayString);

                // 카드 배치
                for (int i = 0; i < 12; ++i)
                {
                    GameObject go = Instantiate(card, this.transform);

                    float x = (i % 4) * 2.4f - 3.6f;
                    float y = (i / 4) * 2.8f - 3.6f;

                    go.transform.position = new Vector2(x, y);
                    go.transform.localScale = new Vector2(2f, 2f);
                    // 카드 인덱스 설정
                    go.GetComponent<Card>().Setting(Efinaldeck[i]);
                }

                GameManager.Instance.cardCount = Efinaldeck.Length;
        }
    private void Shuffle(int[] array)
    {
        System.Random rand = new System.Random();

        int n = array.Length;
        while (n > 1)
        {
            n--;
            // 0부터 n 사이의 임의의 인덱스 k를 선택
            int k = rand.Next(n + 1);

            // array[k]와 array[n]의 값을 서로 교환
            int value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }
}
