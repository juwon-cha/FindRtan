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
        // ī�� ����
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        // ���ǿ� ���� ����
        //arr = arr.OrderBy(x => UnityEngine.Random.Range(0f, 7f)).ToArray();

        Shuffle(arr);

        // ���� �����
        //string arrayString = string.Join(", ", arr);
        //Debug.Log(arrayString);

        // ī�� ��ġ
        for(int i = 0; i < 16; ++i)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f -3f;

            go.transform.position = new Vector2(x, y);

            // ī�� �ε��� ����
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
            // 0���� n ������ ������ �ε��� k�� ����
            int k = rand.Next(n + 1);

            // array[k]�� array[n]�� ���� ���� ��ȯ
            int value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }
}
