using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableItem", menuName = "Item")]
public class ScriptableItem : ScriptableObject
{
    [SerializeField] private int bonusValue;
    [SerializeField] private GameObject particlePrefab;


    public int S_bonus { get { return bonusValue; } }
    public GameObject S_particle { get { return particlePrefab; } }




}
