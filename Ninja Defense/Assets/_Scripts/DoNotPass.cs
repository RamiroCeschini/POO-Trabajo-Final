using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotPass : MonoBehaviour, Iinteractuable
{
    [SerializeField] private EnemiesManager enemiesReference;
    public void Accion()
    {
        if (enemiesReference.Counter == enemiesReference.TotalEnemies)
        {
            SceneManager.LoadScene("Nivel 2");
        }
    }
}
