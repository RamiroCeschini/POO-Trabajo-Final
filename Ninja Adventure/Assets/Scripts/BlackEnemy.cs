using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEnemy : Enemy, Iinteractuable
{
    [SerializeField] private Vector2 dashPosition;
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

    public override void Attack()
    {
        if (Vector2.Distance(new Vector2(target.transform.position.x, target.transform.position.y), EnemyRigidbody2D.position) < attackDistance && canAttack == true)
        {
            dashPosition = target.transform.position;
            gameObject.transform.position = dashPosition - new Vector2(gameObject.transform.position.x / 7 *6 , gameObject.transform.position.y/7 *6);
            canAttack = false;
            Invoke("ResetCoolDown", attackCoolDown);
        }
    }

    public void Accion()
    {
        target.gameObject.GetComponent<PlayerLife>().TakeDamage(damage);
    }
}

