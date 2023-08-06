using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour, IlifeSystem
{
    [SerializeField] private int maxLife;
    public int currentLife;

    private void Awake()
    {
        currentLife = maxLife;
    }
    private int CurrentLife
    {
        get { return currentLife; }
        set
        {
            if (value > 0 && value < maxLife)
            {
                currentLife = value;
            }
            else if (value >= maxLife)
            {
                currentLife = maxLife;
            }

        }
    }

    public void TakeDamage(int damage)
    {
        CurrentLife -= damage;
    }
}
