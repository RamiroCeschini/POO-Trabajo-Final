using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RedEnemy : Enemy, Iinteractuable
{
    [SerializeField] private GameObject leftAttackCollider;
    [SerializeField] private GameObject rightAttackCollider;
    [SerializeField] private Animator weaponAnimator;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        canAttack = true;
        EnemyRigidbody2D = GetComponent<Rigidbody2D>();
        StartAgent();
    }
    private void FixedUpdate()
    {
        MoveEnemy();
        Attack();
    }

    public override void Attack()
    {
        if (Vector2.Distance(new Vector2(target.transform.position.x, target.transform.position.y), EnemyRigidbody2D.position) < attackDistance && canAttack == true)
        {
            if (target.transform.position.x < EnemyRigidbody2D.position.x)
            {
                leftAttackCollider.SetActive(true);
                weaponAnimator.SetTrigger("Attack");
            }
            else
            {
                rightAttackCollider.SetActive(true);
                weaponAnimator.SetTrigger("AttackRight");
            }
            Invoke("DisableColliders", 0.5f);
            canAttack = false;
            Invoke("ResetCoolDown", attackCoolDown);
        }
    }

    public void DisableColliders()
    {
        leftAttackCollider.SetActive(false);
        rightAttackCollider.SetActive(false);
    }

    //Causar daño con Iinteractuable

    public void Accion()
    {
        target.gameObject.GetComponent<PlayerLife>().TakeDamage(damage);
    }
}
