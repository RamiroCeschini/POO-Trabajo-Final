using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3.5f;

    private Animator PlayerAnimation;
    private Rigidbody2D PlayerRigidbody2D;
    private Vector2 playerMovements;

    private Vector2 PlayerMovements
    {
        get { return playerMovements; }
        set { playerMovements = value; }
    }

    void Start()
    {
        PlayerAnimation = GetComponent<Animator>();
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMovements = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        PlayerAnimation.SetFloat("movimientoX", PlayerMovements.x);
        PlayerAnimation.SetFloat("movimientoY", PlayerMovements.y);
        playerMovements.Normalize();

    }
    public void FixedUpdate()
    {
        PlayerRigidbody2D.MovePosition(PlayerRigidbody2D.position + speed * Time.deltaTime * playerMovements);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Iinteractuable>() != null)
        {
            collision.gameObject.GetComponent<Iinteractuable>().Accion();
        }
    }
}
