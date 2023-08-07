using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenAttack : MonoBehaviour
{
    [SerializeField] private Transform shurikenSpawnPoint;
    [SerializeField] private GameObject shurikenPrefab;
    [SerializeField] private int startShurikens;
    [SerializeField] private int maxShurikens;

    private int currentShurikens;
    private int CurrentShurikens
    {
        get { return currentShurikens; }
        set
        {
            if (value > 0 && value < maxShurikens)
            {
                currentShurikens = value;
            }
            else if (value >= maxShurikens)
            {
                currentShurikens = maxShurikens;
            }
            else if (value <= 0)
            {
                currentShurikens = 0;
            }
        }
    }

    private void Start()
    {
        CurrentShurikens = startShurikens;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ShurikenSpawn();
        }
    }
    private void ShurikenSpawn()
    {
        if (currentShurikens > 0) 
        {
            Instantiate(shurikenPrefab, shurikenSpawnPoint.position, shurikenSpawnPoint.rotation);
            CurrentShurikens--;
        }
    }

}