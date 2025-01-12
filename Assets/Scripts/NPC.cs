using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering;

public class Npc : MonoBehaviour
{
    private Outline outline;
    [SerializeField] private float tiempoRotacion;

    [SerializeField] private DialogaSO dialogo;

    [SerializeField] private Transform cameraPoint;
    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    // para que el npc se gire hacia el que le esta interactuando (jugador)
    public void Interactuar(Transform interactuador)
    {
        transform.DOLookAt(interactuador.position, tiempoRotacion, AxisConstraint.Y).OnComplete(() => SistemaDialogo.trono.IniciarDialogo(dialogo, cameraPoint));
    }
    private void OnMouseEnter()
    {
        outline.enabled = true;
    }
    // cuando quitamos el raton por encima
    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}

