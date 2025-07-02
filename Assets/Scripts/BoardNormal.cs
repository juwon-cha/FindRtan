using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEditor;

public class BoardNormal : MonoBehaviour
{
    public GameObject card;
    void Start()
    {
        // 카드 섞기
        int[] Narr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
        Narr = Narr.Take(10).ToArray();
        Narr = Narr.OrderBy(x => UnityEngine.Random.Range(0f, 14f)).ToArray();
        int[] Nspc = { 15, 16, 17,18, 19 };
        Nspc = Nspc.OrderBy(x => UnityEngine.Random.Range(15f, 19f)).ToArray();
        Nspc = Nspc.Take(2).ToArray();

        int[] Ncom = Narr.Concat(Nspc).ToArray();
        int[] Nfinaldeck = Ncom.Concat(Ncom).ToArray();
        Shuffle(Nfinaldeck);

        GameManager.Instance.cardCount = Nfinaldeck.Length;
        GameManager.Instance.Level = 2;
        StartCoroutine(NspawnCard(Nfinaldeck));
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
    }IEnumerator NspawnCard(int[] deck)
    {
        for (int i = 0; i < 24; ++i)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 6) * 2.4f - 6.0f;
            float y = (i / 6) * -1.8f + 2f;

            go.transform.position = new Vector2(x, y);
            go.transform.localScale = new Vector2(2f, 2f);
            go.GetComponent<Card>().Setting(deck[i]);

            yield return new WaitForSeconds(0.1f); // 코루틴은 무적이고 이거 알려주신 튜터님은 신이심 ㄹㅇ
        }
    }
}
