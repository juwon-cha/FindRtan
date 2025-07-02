using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultyButtonManager : MonoBehaviour
{
    public Button hardButton;
    public Text hardButtonTxt;
    public GameObject noticePanel;
    public Text noticeTxt;

    private bool isNormalCleared = false;

    void Start()
    {
        //isNormalCleared = true; // �׽�Ʈ��(�븻�� �� ���·� ����)
        SetHardButtonState();
        noticePanel.SetActive(false);  // ������ �� �ȳ��� ���α�
    }

    void SetHardButtonState()
    {
        if (!isNormalCleared)
        {
            hardButtonTxt.color = Color.gray;
        }
        else
        {
            hardButtonTxt.color = Color.black;
        }
    }

    public void onClickEasy()
    {
        SceneManager.LoadScene("LevelEasy");
    }

    public void onClickNomal()
    {
        SceneManager.LoadScene("LevelNormal");
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
