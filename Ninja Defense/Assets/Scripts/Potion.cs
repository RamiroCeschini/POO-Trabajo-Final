using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Items, Iinteractuable
{
    private void Start()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }
    public void Accion()
    {
        playerGameObject.GetComponent<IlifeSystem>().TakeDamage(abstractBonus);   
    }
}
