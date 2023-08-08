using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    private int gameStage = 1;
    public int GameStage { get { return gameStage; } }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void LoadLevel(int level)
    {
        if(level == 1)
        {
            SceneManager.LoadScene("Nivel 2");
            gameStage++;
        }
        else if (level == 2)
        {
            SceneManager.LoadScene("Victory");
        }
        else if (level == 4)
        {
            SceneManager.LoadScene("Defeat");
        }
    }
}
