using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "Arma")]
public class ArmaSO : ScriptableObject
{
    public int balasCargador;
    public int balasBolsa;
    public float distanciaAtaque;
    public float danhoAtaque;
    public float cadenciaAtaque;  // ratio de disparo

}
