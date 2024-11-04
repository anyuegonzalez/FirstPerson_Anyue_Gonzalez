using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class Enemigo : MonoBehaviour
{
    private NavMeshAgent agent;
    private FirstPerson player;
    private bool ventanaAbierta = false;
    [SerializeField] private Transform attackPoint;
    [SerializeField] float radioDeteccion;
    [SerializeField] private LayerMask queEsJugador;
    [SerializeField] private float danhoAtaque;

    private Animator anim;
   
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       anim = GetComponent<Animator>();

       player = GameObject.FindObjectOfType<FirstPerson>(); //tipo player te devuelve
    }  
    void Update()
    {
        Perseguir();

        if(ventanaAbierta)
        {
           DetectarJugador();
        }
    }
    private void DetectarJugador()
    {
        Collider[] collDetectados = Physics.OverlapSphere(attackPoint.position, radioDeteccion, queEsJugador);

        // si al menos hemos detectado un collider....
        if(collDetectados.Length > 0 )
        {
            for (int i = 0; i < collDetectados.Length; i++)
            {
                collDetectados[i].GetComponent<FirstPerson>().RecibirDanho(danhoAtaque);
            }
        }
    }

    private void Perseguir()
    {
        // tengo q definir como destino la posicion del player
        agent.SetDestination(player.transform.position);


        // si la distancia q nos queda hacia el objeto cae por debajo del stoppingDistance
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            // me paro ante el
            agent.isStopped = true;
            anim.SetBool("Attacking", true);
        }
    }

    #region Eventos de animación
    private void FinAtaque()
    {
        // cuando termino de atacar, vuelvo a moverme
        agent.isStopped = false;
        anim.SetBool("Attacking", false);
    }
    private void AbrirVenatanaAtaque()
    {
        ventanaAbierta = true;
    } 
    private void CerrarVenatanaAtaque()
    {
        ventanaAbierta = false;
    }
    #endregion

}
