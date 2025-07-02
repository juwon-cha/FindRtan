using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultyButtonManager : MonoBehaviour
{
    public Button normalButton; //노말버튼
    public Text normalButtonTxt; //노말버튼텍스트
    public GameObject noticePanel; //문구패널
    public Text noticeTxt; //문구내용
    public GameObject hardPanel; //하드버튼 숨기기용 패널

    public static bool isEasyCleared = false; //이지 모드 클리어 여부
    public static bool isNormalCleared = false; //노말 모드 클리어 여부

    void Start()
    {
        //isEasyCleared = true; // 테스트용(이지를 깬 상태로 가정)
        //isNormalCleared = true; // 테스트용(노말을 깬 상태로 가정)
        
        SetHardButtonState(); //하드 버튼 활성화 상태 여부
        SetNormalButtonState(); // 노말 버튼 활성화 상태 여부
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
            normalButtonTxt.color = Color.black; //이지를 못깼으면 회색
        }
        else
        {
            normalButtonTxt.color = Color.white; //이지를 클리어 했다면 검정색
        }
    }

    public void onClickEasy()
    {
        SceneManager.LoadScene("LevelEasy"); // 이지 난이도 씬으로 이동
    }

    public void onClickNomal()
    {
        if (!isEasyCleared)
        {
            ShowNotice("이지를 깨고 도전해주세요!"); // 이지를 클리어 하지않고 노말 버튼을 눌렀을때 
        }
        else
        {
            SceneManager.LoadScene("LevelNormal"); //클리어 했다면 노말 난이도 씬으로 이동
        }
    }

    public void onClickHard()
    {
        if (!isNormalCleared)
        {
            ShowNotice("노말을 깨고 도전해주세요!"); //노말을 클리어 하지않고 하드 버튼 눌렀을때
        }
        else
        {
            SceneManager.LoadScene("LevelHard"); //하드 난이도 씬으로 이동
        }
    }

    public void SetNormalCleared()
    {
        isNormalCleared = true;
        SetHardButtonState();
    }

    void ShowNotice(string message)
    {
        noticeTxt.text = message; //안내 메세지 텍스트
        noticePanel.SetActive(true); // 안내 메세지 호출
    }

    public void CloseNotice()
    {
        noticePanel.SetActive(false); // 안내창 닫기
    }
}
