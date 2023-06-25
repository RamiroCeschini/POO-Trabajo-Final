using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : Enemy
{
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackCoolDown;
    private bool canAttack;

    private void Start()
    {
        canAttack = true;
        EnemyRigidbody2D = GetComponent<Rigidbody2D>();
    }
    private new void FixedUpdate()
    {
        MoveEnemy();
        Attack();
    }

    public void Attack()
    {
        if (Vector2.Distance(new Vector2(target.transform.position.x, target.transform.position.y), EnemyRigidbody2D.position) < attackDistance && canAttack == true)
        {
            Debug.Log("Atack");
            canAttack = false;
            Invoke("ResetCoolDown", attackCoolDown);
        }
    }

    private void ResetCoolDown()
    {
        canAttack = true;
    }
}
