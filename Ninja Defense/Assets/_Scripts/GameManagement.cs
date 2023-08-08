using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{

    public static GameManagement Instance { get; private set; }

    private int gameStage = 1;
    private int currentLifePlayer = 0;
    private int currentShurikens = -1;
    public int GameStage { get { return gameStage; } set { gameStage = value; } }
    public int CurrentLifePlayer { get {  return currentLifePlayer; } set { currentLifePlayer = value; } }
    public int CurrentShurikens { get { return currentShurikens; } set { currentShurikens = value; } }
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
            currentLifePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>().CurrentLife;
            currentShurikens = GameObject.FindGameObjectWithTag("ShuriManager").GetComponent<ShurikenAttack>().CurrentShurikens;
            SceneManager.LoadScene("Nivel 2");
            gameStage++;
        }
        else if (level == 2)
        {
            SceneManager.LoadScene("Victory");
            gameStage = 1;
        }
        else if (level == 4)
        {
            SceneManager.LoadScene("Defeat");
        }
    }
}
