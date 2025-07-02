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
        //isEasyCleared = true; // 테스트용(이지를 깬 상태로 가정)
        //isNormalCleared = true; // 테스트용(노말을 깬 상태로 가정)
        
        SetHardButtonState();
        SetNormalButtonState();
        noticePanel.SetActive(false);  // 시작할 때 안내판 꺼두기
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
            ShowNotice("이지를 깨고 도전해주세요!");
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
            ShowNotice("노말을 깨고 도전해주세요!");
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
