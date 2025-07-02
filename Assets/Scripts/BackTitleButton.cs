using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTitleButton : MonoBehaviour
{
    public void OnClickBack()
    {
        AudioManager.Instance.SetPitch(1f);
        SceneManager.LoadScene("StartScene");
    }
}
