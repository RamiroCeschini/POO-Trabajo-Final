using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotPass : MonoBehaviour, Iinteractuable
{
    [SerializeField] private EnemiesManager enemiesManager;
    public void Accion()
    {
        if(enemiesManager.Counter == enemiesManager.TotalEnemies)
        {
            int stage = GameManagement.Instance.GameStage;
            GameManagement.Instance.LoadLevel(stage);
        }

    }
}
