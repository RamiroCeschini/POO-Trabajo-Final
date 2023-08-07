using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEnemy : Enemy
{
    private Vector2 dashPosition;
    [SerializeField] private GameObject damageZone;
    private void Start()
    {
        damageZone.SetActive(false);
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
            dashPosition = target.transform.position;
            agent.isStopped = true;
            damageZone.SetActive(true);
            isAttacking = true;
            Invoke("ChargeAttack", 2f);
        }
    }

    private void ChargeAttack()
    {
        gameObject.transform.position = dashPosition;
        agent.isStopped = false;
        canAttack = false;
        Invoke("ResetCoolDown", attackCoolDown);
        Invoke("ResetZone", 1f);
    }

    private void ResetZone()
    {
        damageZone.SetActive(false);
        isAttacking = false;
    }

}
