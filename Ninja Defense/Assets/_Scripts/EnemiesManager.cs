using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private Text enemiesText;
    [SerializeField] private Text enemiesTextShadow;
    private int counter = -1;
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
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        EnemiesText();
    }
    void EnemiesText()
    {
        counter++;
        enemiesText.text = "ENEMIES: " + counter + "/" + totalEnemies;
        enemiesTextShadow.text = "ENEMIES: " + counter + "/" + totalEnemies;
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
