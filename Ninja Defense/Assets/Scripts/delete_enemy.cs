using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_enemy : MonoBehaviour, IlifeSystem
{
    public int life = 50;
    private int enemyDamage = 5;
    public void TakeDamage(int damage)
    {
        life -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.GetComponent<IlifeSystem>() != null)
        {
            Debug.Log("colisio con player");
            collision.gameObject.GetComponent<IlifeSystem>().TakeDamage(enemyDamage);
        }
    }
}
