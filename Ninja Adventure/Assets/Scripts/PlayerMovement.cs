using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;

    Rigidbody2D PlayerRigidbody2D;
    private Vector2 playerMovements;

    public Vector2 PlayerMovements
    {
        get { return playerMovements; }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovements = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        playerMovements.Normalize();
    }

    public void FixedUpdate()
    {
        PlayerRigidbody2D.MovePosition(PlayerRigidbody2D.position + speed * Time.deltaTime * playerMovements);
    }
}
