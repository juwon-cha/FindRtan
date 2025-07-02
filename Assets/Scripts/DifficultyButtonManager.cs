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
        //isNormalCleared = true; // 테스트용(노말을 깬 상태로 가정)
        SetHardButtonState();
        noticePanel.SetActive(false);  // 시작할 때 안내판 꺼두기
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
