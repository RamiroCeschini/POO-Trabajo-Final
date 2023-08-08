using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IlifeSystem
{
    [SerializeField] protected ScriptableEnemigo enemyData;
    protected float attackDistance;
    protected float attackCoolDown;
    protected int damage;
    protected float speed;

    protected Rigidbody2D EnemyRigidbody2D;
    protected GameObject target;
    protected NavMeshAgent agent;

    protected bool canAttack;
    protected Animator enemyAnimator;
    protected bool isAttacking;

    [SerializeField] protected int life;
    [SerializeField] protected int maxLife;

    public static event Action enemyEvent;

    protected void MoveEnemy()
    {
        if (Vector2.Distance(new Vector2(target.transform.position.x, target.transform.position.y), EnemyRigidbody2D.position) < 8f)
        {
            agent.SetDestination(target.transform.position);
            enemyAnimator.SetBool("isWalking", true);
        }

        else if (agent.velocity.magnitude == 0)
        {
            enemyAnimator.SetBool("isWalking", false);
        }

    }

    protected virtual void Attack() { }

    protected void ResetCoolDown()
    {
        canAttack = true;
    }

    protected void StartAgent()
    {
        enemyAnimator = GetComponent<Animator>();
        EnemyRigidbody2D = GetComponent<Rigidbody2D>();

        canAttack = true;
        isAttacking = false;

        target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
        speed = enemyData.S_speed;
        damage = enemyData.S_damage;
        attackDistance = enemyData.S_attackDistance;
        attackCoolDown = enemyData.S_attackCooldown;
        maxLife = enemyData.S_maxLife;
        life = maxLife;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IlifeSystem>() != null && isAttacking)
        {
            collision.gameObject.GetComponent<IlifeSystem>().TakeDamage(damage);
            isAttacking = false;
        }
    }

    public void TakeDamage(int damage)
    {
        life = Mathf.Clamp(life - damage ,0, maxLife);
        if (life == 0)
        {
            enemyEvent?.Invoke();
            Destroy(gameObject);
        }
    }
}