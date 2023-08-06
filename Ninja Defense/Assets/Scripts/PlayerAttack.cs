using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int damage;
    private Animator swordAnimator;
    private bool isAttacking;

    public bool IsAttacking
    {
        get { return isAttacking; }
        private set { isAttacking = value; }
    }
    void Start()
    {
        swordAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        LAMouse();
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void LAMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;

        Vector2 scale = transform.localScale;

        if (direction.x > 0 )
        {
            scale.x = 1;
        }

        else if (direction.x < 0)
        {
            scale.x = -1;
        }

        transform.localScale = scale;
    }

    private void Attack()
    {
        if (!IsAttacking)
        {
            swordAnimator.SetTrigger("Attack");
            IsAttacking = true;
        }
    }

    public void ResetIsAttacking()
    {
        IsAttacking = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("colision");
        if (collision.gameObject.GetComponent<IlifeSystem>() != null && isAttacking)
        {
            Debug.Log("colision con enemigo");
            collision.gameObject.GetComponent<IlifeSystem>().TakeDamage(damage);
        }
    }
}
