using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void Start()
    {
        // 애니메이션 재생을 위해 타임 스케일 1로 설정
        Time.timeScale = 1f;
    }

    public void OnClickLevelSelctBtn()
    {
        Debug.Log("Load Level Select Scene");

        SceneManager.LoadScene("DifficultyScene");
    }

    public void OnClickCardCollectionBtn()
    {
        Debug.Log("Load Card Collection Scene");

        SceneManager.LoadScene("CardbookScene");
    }
}
