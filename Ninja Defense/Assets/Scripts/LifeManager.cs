using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private Image lifeBar;

    private PlayerLife playerLifeSystem;

    private void OnEnable()
    {
        PlayerLife.lifeEvent += UpdateLife;
    }

    private void OnDisable()
    {
        PlayerLife.lifeEvent -= UpdateLife;
    }
    private void Start()
    {
        playerLifeSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        UpdateLife();
    }

    public void UpdateLife()
    {
        float currentLife = playerLifeSystem.CurrentLife;
        float maxLife = playerLifeSystem.MaxLife;
        lifeBar.fillAmount = currentLife / maxLife;
    }

}