using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WaterEffect : MonoBehaviour
{
    private Volume effect;
    [SerializeField] private float velocidad;
    void Start()
    {
        effect = GetComponent<Volume>();
    }
    void Update()
    {

       
        //busca en tu profile si tienes el efecto lens diostorsion
        if(effect.profile.TryGet(out LensDistortion distorsion))
        {
            FloatParameter miVariable = new FloatParameter( 1 + Mathf.Cos(velocidad * Time.time) / 2);
            FloatParameter miVariable2 = new FloatParameter(1 + Mathf.Sin(velocidad * Time.time) / 2);
            distorsion.xMultiplier.SetValue(miVariable);
            distorsion.xMultiplier.SetValue(miVariable2);
        }
    }
}
