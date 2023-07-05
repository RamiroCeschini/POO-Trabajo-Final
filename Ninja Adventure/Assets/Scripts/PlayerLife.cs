using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour, IlifeSystem
{
    [SerializeField] private int vidas;
    public delegate void VidaEvent();
    public static VidaEvent vidaEvent;
    
    public void TakeDamage(int damage)
    {
        vidas -= damage;
        CheckLife();

    }
    public void CheckLife()
    {
        if (vidas == 0)
        {
            Debug.Log("Perdiste");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisiono ");
        if (collision.gameObject.GetComponentInParent<Iinteractuable>() != null)
        {
            Debug.Log("Colisiono con interactuable");
            collision.gameObject.GetComponentInParent<Iinteractuable>().Accion();
        }
    }


}
