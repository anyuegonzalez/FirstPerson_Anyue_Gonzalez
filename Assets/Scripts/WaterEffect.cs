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
            FloatParameter miVariable = new FloatParameter(Mathf.Cos(velocidad * Time.time));
            FloatParameter miVariable2 = new FloatParameter(Mathf.Cos(velocidad * Time.time));
            distorsion.xMultiplier.SetValue(miVariable);
            distorsion.xMultiplier.SetValue(miVariable2);
        }
    }
}
