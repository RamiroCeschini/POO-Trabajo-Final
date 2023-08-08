using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Items, Iinteractuable
{
    private bool rewardGiven = false;
    private Animator chestAnimator;
    private ShurikenAttack shurikenReference;
    private void Start()
    {
        GeneralStart();
        shurikenReference = playerGameObject.GetComponentInChildren<ShurikenAttack>();
        chestAnimator = GetComponent<Animator>();
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
        if (!rewardGiven)
        {
            rewardGiven = true;
            shurikenReference.AddShuriken(abstractBonus);
            Instantiate(itemParticle, gameObject.transform.position, gameObject.transform.rotation);
            chestAnimator.SetTrigger("chestOpen");
        }
    }

}

