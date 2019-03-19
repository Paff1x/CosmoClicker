using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void OnPlayClick()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    public void OnBackToMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
