using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Board : MonoBehaviour
{
    public GameObject card;

    void Start()
    {
        // 카드 섞기
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        // 조건에 따라 정렬
        //arr = arr.OrderBy(x => UnityEngine.Random.Range(0f, 7f)).ToArray();

        Shuffle(arr);

        // 셔플 디버깅
        //string arrayString = string.Join(", ", arr);
        //Debug.Log(arrayString);

        // 카드 배치
        for(int i = 0; i < 16; ++i)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f -3f;

            go.transform.position = new Vector2(x, y);

            // 카드 인덱스 설정
            go.GetComponent<Card>().Setting(arr[i]);
        }

        GameManager.Instance.cardCount = arr.Length;
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
