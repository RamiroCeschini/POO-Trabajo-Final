using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour, IlifeSystem
{
    [SerializeField] private int maxLife;
    private int currentLife;

    public static event Action lifeEvent;
    private void Awake()
    {
        currentLife = maxLife;
    }

    public int MaxLife
    {
        get { return maxLife; }
    }
    public int CurrentLife
    {
        get { return currentLife; }
        private set
        {
            if (value > 0 && value < maxLife)
            {
                currentLife = value;
            }
            else if (value >= maxLife)
            {
                currentLife = maxLife;
            }
            else if (value <= 0)
            {
                currentLife = 0;
                GameManager.Instance.LoadLevel(4);
            }

        }
    }

    public void TakeDamage(int damage)
    {
        CurrentLife -= damage;
        lifeEvent?.Invoke();
    }


}