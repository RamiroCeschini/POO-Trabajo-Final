using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] protected ScriptableItem itemData;
    protected GameObject playerGameObject;
    protected int abstractBonus;
    protected GameObject itemParticle;
    
    protected void GeneralStart()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");

        abstractBonus = itemData.S_bonus;
        itemParticle = itemData.S_particle;
    }
}
