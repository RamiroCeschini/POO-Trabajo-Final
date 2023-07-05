using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableEnemigo",menuName = "Enemy")]
public class ScriptableEnemigo : ScriptableObject
{
    [SerializeField] private int s_damage;
    [SerializeField] private float s_speed;
    [SerializeField] private float s_attackDistance;
    [SerializeField] private float s_attackCooldown;

    public int S_damage { get { return s_damage; } }
    public float S_speed { get {  return s_speed; } }
    public float S_attackDistance { get {  return s_attackDistance; } }
    public float S_attackCooldown { get {  return s_attackCooldown; } }


  
}
