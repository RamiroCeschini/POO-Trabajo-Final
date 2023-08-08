using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private Text enemiesText;
    [SerializeField] private Text enemiesTextShadow;
    private int counter;
    private int totalEnemies;

    public int Counter
    {
        get { return counter; }
    }

    public int TotalEnemies
    {
        get { return totalEnemies; }
    }
    private void Start()
    {
        StartManager();
    }
    void EnemiesText()
    {
        counter++;
        enemiesText.text = "ENEMIES: " + counter + "/" + totalEnemies;
        enemiesTextShadow.text = "ENEMIES: " + counter + "/" + totalEnemies;
        if (counter == totalEnemies)
        {
            enemiesText.text = "Go to the exit!";
            enemiesTextShadow.text = "Go to the exit!";
        }
    }

    public void StartManager()
    {
        counter = -1;
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        EnemiesText();
    }

    private void OnEnable()
    {
        Enemy.enemyEvent += EnemiesText;
    }
    private void OnDisable()
    {
        Enemy.enemyEvent -= EnemiesText;
    }
}
