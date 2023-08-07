using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected ScriptableEnemigo enemyData;
    protected float speed;
    protected Rigidbody2D EnemyRigidbody2D;
    protected GameObject target;
    protected NavMeshAgent agent;
    protected bool canAttack;
    protected float attackDistance;
    protected float attackCoolDown;
    protected int damage;
    protected Animator enemyAnimator;

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
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        speed = enemyData.S_speed;
        damage = enemyData.S_damage;
        attackDistance = enemyData.S_attackDistance;
        attackCoolDown = enemyData.S_attackCooldown;
    }

}