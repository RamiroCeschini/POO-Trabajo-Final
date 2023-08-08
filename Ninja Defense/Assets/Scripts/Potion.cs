using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Items, Iinteractuable
{
    private void Start()
    {
        GeneralStart();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Accion();
        }
    }
    public void Accion()
    {
     //   playerGameObject.GetComponent<IlifeSystem>().TakeDamage(-abstractBonus);
        Instantiate(itemParticle, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(this.gameObject);
    }
}
