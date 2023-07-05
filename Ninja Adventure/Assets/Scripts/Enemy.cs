using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public ScriptableEnemigo enemyData;
    public float speed;
    public Rigidbody2D EnemyRigidbody2D;
    public GameObject target;
    public NavMeshAgent agent;
    public bool canAttack;
    public float attackDistance;
    public float attackCoolDown;
    public int damage;

    public void MoveEnemy()
    {
        if (Vector2.Distance(new Vector2(target.transform.position.x, target.transform.position.y), EnemyRigidbody2D.position) < 8f)
        {
            agent.SetDestination(target.transform.position);
        }

    }

    public virtual void Attack()  { }
    public void ResetCoolDown()
    {
        canAttack = true;
    }

    public void StartAgent()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        speed = enemyData.S_speed;
        damage = enemyData.S_damage;
        attackDistance = enemyData.S_attackDistance;
        attackCoolDown = enemyData.S_attackCooldown;
    }

}
