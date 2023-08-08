using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShurikenManager : MonoBehaviour
{
    [SerializeField] private Text shurikenText;
    [SerializeField] private Text shurikenTextShadow;
    [SerializeField] private ShurikenAttack shurikenReference;

    void ShurikenText()
    {
        shurikenText.text = "SHURIKENS: " + shurikenReference.CurrentShurikens;
        shurikenTextShadow.text = "SHURIKENS: " + shurikenReference.CurrentShurikens;
    }

    private void OnEnable()
    {
        ShurikenAttack.shurikenEvent += ShurikenText;
    }

    private void OnDisable()
    {
        ShurikenAttack.shurikenEvent -= ShurikenText;
    }
}
