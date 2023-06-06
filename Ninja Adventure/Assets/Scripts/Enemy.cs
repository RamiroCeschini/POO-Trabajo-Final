using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;

    Rigidbody2D EnemyRigidbody2D;
    private Vector2 enemyMovements;
    public GameObject target;

    public Vector2 EnemyMovements
    {
        get { return enemyMovements; }
    }

    void Start()
    {
        EnemyRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        enemyMovements = new Vector2(target.transform.position.x, target.transform.position.y) - EnemyRigidbody2D.position;
        enemyMovements.Normalize();
    }

    public void FixedUpdate()
    {
        if (Vector2.Distance(new Vector2(target.transform.position.x, target.transform.position.y), EnemyRigidbody2D.position) < 5f)
        {
            EnemyRigidbody2D.MovePosition(EnemyRigidbody2D.position + speed * Time.deltaTime * enemyMovements);
        }
       
    }

}
