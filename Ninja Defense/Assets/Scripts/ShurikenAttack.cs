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

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ShurikenSpawn();
        }
    }

    public void AddShuriken(int shurikenAmount)
    {
        CurrentShurikens += shurikenAmount;
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
