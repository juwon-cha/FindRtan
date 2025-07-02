using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void OnClickRetry()
    {
        //SceneManager.LoadScene("MainScene");
        AudioManager.Instance.SetPitch(1f);
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickReturn()
    {
        AudioManager.Instance.SetPitch(1f);
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }
}
