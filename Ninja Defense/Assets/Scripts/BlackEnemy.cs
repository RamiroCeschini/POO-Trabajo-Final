using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEnemy : Enemy
{
    private Vector2 dashPosition;
    private void Start()
    {
        canAttack = true;
        EnemyRigidbody2D = GetComponent<Rigidbody2D>();
        StartAgent();
        target = GameObject.FindGameObjectWithTag("Player");
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
            Invoke("ChargeAttack", 2f);
        }
    }

    private void ChargeAttack()
    {
        gameObject.transform.position = dashPosition;
        agent.isStopped = false;
        canAttack = false;
        Invoke("ResetCoolDown", attackCoolDown);
    }

}
