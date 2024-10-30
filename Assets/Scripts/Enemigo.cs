using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private NavMeshAgent agent;
    private FirstPerson player;
   
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();

       player = GameObject.FindObjectOfType<FirstPerson>(); //tipo player te devuelve
    }  
    void Update()
    {
        // tengo q definir como destino la posicion del player
        agent.SetDestination(player.transform.position);
    }
}
