using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "Dialogo")]
public class DialogaSO : ScriptableObject
{
    [TextArea(3, 5)] // te brinda mas espacio en unity tipo string
    public string[] frases;

    public float tiempoEntreLetras;


}
