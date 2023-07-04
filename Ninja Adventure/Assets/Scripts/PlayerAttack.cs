using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Transform WeaponDirection;

    private PlayerMovement NinjaScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject PlayerObject = GameObject.FindWithTag("Player");
        if (PlayerObject != null)
        {
            NinjaScript = PlayerObject.GetComponent<PlayerMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Se actualiza la posicion del Transform para que se pueda apuntar segun la direccion del jugador.
        WeaponDirection.transform.position = new Vector2(
            NinjaScript.transform.position.x + NinjaScript.PlayerMovements.x / 6.8f,
            NinjaScript.transform.position.y + NinjaScript.PlayerMovements.y / 6.8f);

        //Se compara si el jugador esta en movimiento para rotar el arma.
        if(NinjaScript.PlayerMovements != Vector2.zero)
        {
            Quaternion ToRotation = Quaternion.LookRotation(WeaponDirection.forward, -NinjaScript.PlayerMovements);
            WeaponDirection.transform.rotation = ToRotation;
        }
        else
        {
            WeaponDirection.transform.localPosition = new Vector2(-0.004f, -0.119f);
        }
    }
}
