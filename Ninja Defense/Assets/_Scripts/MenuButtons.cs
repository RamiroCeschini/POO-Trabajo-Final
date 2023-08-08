using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Nivel 1");
        if (GameManagement.Instance != null)
        {
            GameManagement.Instance.GameStage = 1;
            GameManagement.Instance.CurrentLifePlayer = 0;
            GameManagement.Instance.CurrentShurikens = -1;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
