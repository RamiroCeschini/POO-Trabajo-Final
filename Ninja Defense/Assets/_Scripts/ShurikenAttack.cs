using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenAttack : MonoBehaviour
{
    [SerializeField] private Transform shurikenSpawnPoint;
    [SerializeField] private GameObject shurikenPrefab;
    [SerializeField] private int startShurikens;
    [SerializeField] private int maxShurikens;

    public delegate void ShurikenEvent();
    public static ShurikenEvent shurikenEvent;

    private int currentShurikens;
    public int CurrentShurikens
    {
        get { return currentShurikens; }
        private set
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
        if (GameManagement.Instance.CurrentShurikens == -1)
        {
            currentShurikens = startShurikens;
        }
        else
        {
            currentShurikens = GameManagement.Instance.CurrentShurikens;
        }
        shurikenEvent?.Invoke();
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
        shurikenEvent?.Invoke();
    }

    private void ShurikenSpawn()
    {
        if (currentShurikens > 0) 
        {
            Instantiate(shurikenPrefab, shurikenSpawnPoint.position, shurikenSpawnPoint.rotation);
            CurrentShurikens--;
            shurikenEvent?.Invoke();
        }
    }

}
