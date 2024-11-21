using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WaterEffect : MonoBehaviour
{
    private Volume effect;
    void Start()
    {
        effect = GetComponent<Volume>();
    }
    void Update()
    {
        //busca en tu profile si tienes el efecto lens diostorsion
        if(effect.profile.TryGet(out LensDistortion distorsion))
        {
            //distorsion.xMultiplier;
        }
    }
}
