using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultyButtonManager : MonoBehaviour
{
    public Button normalButton;
    public Text normalButtonTxt;
    public GameObject noticePanel;
    public Text noticeTxt;
    public GameObject hardPanel;

    public static bool isEasyCleared = false;
    public static bool isNormalCleared = false;

    void Start()
    {
        //isEasyCleared = true; // �׽�Ʈ��(������ �� ���·� ����)
        //isNormalCleared = true; // �׽�Ʈ��(�븻�� �� ���·� ����)
        
        SetHardButtonState();
        SetNormalButtonState();
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
            normalButtonTxt.color = Color.gray;
        }
        else
        {
            normalButtonTxt.color = Color.black;
        }
    }

    public void onClickEasy()
    {
        SceneManager.LoadScene("LevelEasy");
    }

    public void onClickNomal()
    {
        if (!isEasyCleared)
        {
            ShowNotice("������ ���� �������ּ���!");
        }
        else
        {
            SceneManager.LoadScene("LevelNormal");
        }
    }

    public void onClickHard()
    {
        if (!isNormalCleared)
        {
            ShowNotice("�븻�� ���� �������ּ���!");
        }
        else
        {
            SceneManager.LoadScene("LevelHard");
        }
    }

    public void SetNormalCleared()
    {
        isNormalCleared = true;
        SetHardButtonState();
    }

    void ShowNotice(string message)
    {
        noticeTxt.text = message;
        noticePanel.SetActive(true);
    }

    public void CloseNotice()
    {
        noticePanel.SetActive(false);
    }
}
