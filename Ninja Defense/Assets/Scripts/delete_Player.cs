using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_Player : MonoBehaviour, IlifeSystem
{

    public int life = 50;
    public void TakeDamage(int damage)
    {
        life -= damage;
    }
}
