using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotPass : MonoBehaviour, Iinteractuable
{
    public void Accion()
    {
        int stage = GameManagement.Instance.GameStage;
        GameManagement.Instance.LoadLevel(stage);
    }
}
