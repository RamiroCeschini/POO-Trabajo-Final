using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    [SerializeField]
    private Text _vidaText;
    private int contador;
    private PlayerLife vidaJugador;

    private void OnEnable()
    {
        PlayerLife.vidaEvent += VidaText;
    }

    private void OnDisable()
    {
        PlayerLife.vidaEvent -= VidaText;
    }
    private void Start()
    {
        vidaJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        contador = vidaJugador.cantVidas;
    }
    void VidaText()
    {
        contador = vidaJugador.cantVidas;
        _vidaText.text  = "Vidas: " + contador;
        
    }
}
