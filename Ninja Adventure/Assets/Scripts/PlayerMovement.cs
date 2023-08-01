using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;

    Animator PlayerAnimation;
    public Animator swordAnimator;
    Rigidbody2D PlayerRigidbody2D;
    private Vector2 playerMovements;

    public Vector2 PlayerMovements
    {
        get { return playerMovements; }
    }

    void Start()
    {
        PlayerAnimation = GetComponent<Animator>();
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerMovements = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        PlayerAnimation.SetFloat("movimientoX", playerMovements.x);
        PlayerAnimation.SetFloat("movimientoY", playerMovements.y);
        playerMovements.Normalize();
        Attack();

    }

    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            swordAnimator.SetTrigger("Ataque");
        }
    }

    public void FixedUpdate()
    {
        PlayerRigidbody2D.MovePosition(PlayerRigidbody2D.position + speed * Time.deltaTime * playerMovements);
    }
}
