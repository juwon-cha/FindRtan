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
        // ī�� ����
        int[] Narr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
        Narr = Narr.Take(10).ToArray();
        Narr = Narr.OrderBy(x => UnityEngine.Random.Range(0f, 14f)).ToArray();
        int[] Nspc = { 15, 16, 17,18, 19 };
        Nspc = Nspc.OrderBy(x => UnityEngine.Random.Range(15f, 19f)).ToArray();
        Nspc = Nspc.Take(2).ToArray();

        int[] Ncom = Narr.Concat(Nspc).ToArray();
        int[] Nfinaldeck = Ncom.Concat(Ncom).ToArray();
        Shuffle(Nfinaldeck);

        // ���� �����
        //string arrayString = string.Join(", ", arr);
        //Debug.Log(arrayString);

        // ī�� ��ġ
        for (int i = 0; i < 24; ++i)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 6) * 2.4f - 6.0f; 
            float y = (i / 6) * -1.8f +2f;

            go.transform.position = new Vector2(x, y);
            go.transform.localScale = new Vector2(4.0f, 4.0f);

            // ī�� �ε��� ����
            go.GetComponent<Card>().Setting(Nfinaldeck[i]);
        }

        GameManager.Instance.cardCount = Nfinaldeck.Length;
        GameManager.Instance.Level = 2;
    }
    private void Shuffle(int[] array)
    {
        System.Random rand = new System.Random();

        int n = array.Length;
        while (n > 1)
        {
            n--;
            // 0���� n ������ ������ �ε��� k�� ����
            int k = rand.Next(n + 1);

            // array[k]�� array[n]�� ���� ���� ��ȯ
            int value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }
}
