using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotPass : MonoBehaviour, Iinteractuable
{
    public void Accion()
    {
        int stage = GameManager.Instance.GameStage;
        GameManager.Instance.LoadLevel(stage);
    }
}