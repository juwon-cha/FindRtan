using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
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
