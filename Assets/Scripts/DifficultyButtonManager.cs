using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultyButtonManager : MonoBehaviour
{
    public Button normalButton; //�븻��ư
    public Text normalButtonTxt; //�븻��ư�ؽ�Ʈ
    public GameObject noticePanel; //�����г�
    public Text noticeTxt; //��������
    public GameObject hardPanel; //�ϵ��ư ������ �г�

    public static bool isEasyCleared = false; //���� ��� Ŭ���� ����
    public static bool isNormalCleared = false; //�븻 ��� Ŭ���� ����

    void Start()
    {
        //isEasyCleared = true; // �׽�Ʈ��(������ �� ���·� ����)
        //isNormalCleared = true; // �׽�Ʈ��(�븻�� �� ���·� ����)
        
        SetHardButtonState(); //�ϵ� ��ư Ȱ��ȭ ���� ����
        SetNormalButtonState(); // �븻 ��ư Ȱ��ȭ ���� ����
        noticePanel.SetActive(false);  // ������ �� �ȳ��� ���α�
    }

    void SetHardButtonState()
    {
        if (!isNormalCleared)
        {
            hardPanel.SetActive(false);
        }
        else
        {
            hardPanel.SetActive(true);
        }
    }
    private void Update()
    {
        SetHardButtonState();
        SetNormalButtonState();
    }

    void SetNormalButtonState()
    {
        if (!isEasyCleared)
        {
            normalButtonTxt.color = Color.black; //������ �������� ȸ��
        }
        else
        {
            normalButtonTxt.color = Color.white; //������ Ŭ���� �ߴٸ� ������
        }
    }

    public void onClickEasy()
    {
        SceneManager.LoadScene("LevelEasy"); // ���� ���̵� ������ �̵�
    }

    public void onClickNomal()
    {
        if (!isEasyCleared)
        {
            ShowNotice("������ ���� �������ּ���!"); // ������ Ŭ���� �����ʰ� �븻 ��ư�� �������� 
        }
        else
        {
            SceneManager.LoadScene("LevelNormal"); //Ŭ���� �ߴٸ� �븻 ���̵� ������ �̵�
        }
    }

    public void onClickHard()
    {
        if (!isNormalCleared)
        {
            ShowNotice("�븻�� ���� �������ּ���!"); //�븻�� Ŭ���� �����ʰ� �ϵ� ��ư ��������
        }
        else
        {
            SceneManager.LoadScene("LevelHard"); //�ϵ� ���̵� ������ �̵�
        }
    }

    public void SetNormalCleared()
    {
        isNormalCleared = true;
        SetHardButtonState();
    }

    void ShowNotice(string message)
    {
        noticeTxt.text = message; //�ȳ� �޼��� �ؽ�Ʈ
        noticePanel.SetActive(true); // �ȳ� �޼��� ȣ��
    }

    public void CloseNotice()
    {
        noticePanel.SetActive(false); // �ȳ�â �ݱ�
    }
}
