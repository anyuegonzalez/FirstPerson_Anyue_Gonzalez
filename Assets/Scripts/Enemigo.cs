using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private NavMeshAgent agent;
    private FirstPerson player;

    private Animator animator;
   
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       animator = GetComponent<Animator>();

       player = GameObject.FindObjectOfType<FirstPerson>(); //tipo player te devuelve
    }  
    void Update()
    {
        // tengo q definir como destino la posicion del player
        agent.SetDestination(player.transform.position);


        // si la distancia q nos queda hacia el objeto cae por debajo del stoppingDistance
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
        }
    }
    public void ActivarAnimacion()
    {
        animator.
    }

    //Activar animacion de ataque 
    // 1. Obtener el componente con el que podemos tirar animaciones -> animator y almacenarlo en un avariable
    // 2. a traves de dicha variable buscar un metodo para activar el bool attacking

}
