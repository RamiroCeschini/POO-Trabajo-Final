using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RedEnemy : Enemy
{
    [SerializeField] private Animator weaponAnimator;

    private void Start()
    {
        StartAgent();
    }
    private void FixedUpdate()
    {
        MoveEnemy();
        Attack();
    }

    protected override void Attack()
    {
        if (Vector2.Distance(new Vector2(target.transform.position.x, target.transform.position.y), EnemyRigidbody2D.position) < attackDistance && canAttack == true)
        {
            if (target.transform.position.x < EnemyRigidbody2D.position.x)
            {
                weaponAnimator.SetTrigger("AttackLeft");
            }
            else
            {
                weaponAnimator.SetTrigger("AttackRight");
            }
            isAttacking = true;
            Invoke("DisableColliders", 0.5f);
            canAttack = false;
            Invoke("ResetCoolDown", attackCoolDown);
        }
    }

    private void DisableColliders()
    {
        isAttacking = false;
    }

}