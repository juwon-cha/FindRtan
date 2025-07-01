using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTitleButton : MonoBehaviour
{
    public void OnClickBack()
    {
        SceneManager.LoadScene("StartScene");
    }
}
