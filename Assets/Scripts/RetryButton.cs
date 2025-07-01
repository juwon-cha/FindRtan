using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void OnClickRetry()
    {
        //SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickReturn()
    {
        SceneManager.LoadScene("StartScene");
    }
}
