using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private NavMeshAgent agent;
    private FirstPerson player;
    private bool attacking = false;

    private Animator anim;
   
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       anim = GetComponent<Animator>();

       player = GameObject.FindObjectOfType<FirstPerson>(); //tipo player te devuelve
    }  
    void Update()
    {
        // tengo q definir como destino la posicion del player
        agent.SetDestination(player.transform.position);


        // si la distancia q nos queda hacia el objeto cae por debajo del stoppingDistance
        if(agent.remainingDistance <= agent.stoppingDistance)
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

    } 
    private void CerrarVenatanaAtaque()
    {

    }
    #endregion

}
