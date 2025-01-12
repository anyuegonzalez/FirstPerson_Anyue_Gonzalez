using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    private bool danhoRealizado = false;
    [SerializeField] private float vidas;

    [SerializeField] int puntosDeMuerte;

    private Rigidbody[] huesos; // array de rigidbodys

    private Animator anim;

    public float Vidas { get => vidas; set => vidas = value; }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        huesos = GetComponentsInChildren<Rigidbody>();
        player = GameObject.FindObjectOfType<FirstPerson>(); //tipo player te devuelve

        CambiarEstadoHuesos(true);
    }

    void Update()
    {
        Perseguir();

        // solo si la ventana y esta abierta, y aun no ha hecho daño
        if(ventanaAbierta && danhoRealizado == false)
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
            danhoRealizado = true;
        }
    }

    private void Perseguir()
    {
        // tengo q definir como destino la posicion del player
        agent.SetDestination(player.transform.position);


        // si la distancia q nos queda hacia el objeto cae por debajo del stoppingDistance
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // me paro ante el
            agent.isStopped = true;
            anim.SetBool("Attacking", true);
            EnfocarPlayer();
        }
    }
    private void EnfocarPlayer()
    {
        // calculo el vector que enfoque al jugador
        Vector3 direccionAPlayer = (player.transform.position - this.gameObject.transform.position).normalized; // se puede poner "transform.position" solamente
        
        // me aseguro que no se vuelque el enemigo al ver al player
        direccionAPlayer.y = 0;

        // calculo la rotacion a la que me tengo que girar para orientarme en esa direccion
        transform.rotation = Quaternion.LookRotation(direccionAPlayer);
    }
    public void Morir()
    {
        agent.enabled = false;
        anim.enabled = false;
        CambiarEstadoHuesos(false);
        Destroy(gameObject, 10); // se destruye pasado esos frames el objeto
    }
    private void CambiarEstadoHuesos(bool estado)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = estado;
        }
    }
    private void Muerte()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddPoints(puntosDeMuerte);
        }

        // Destruir al enemigo
        Destroy(gameObject);
    }
    #region Eventos de animación
    private void FinAtaque()
    {
        // cuando termino de atacar, vuelvo a moverme
        agent.isStopped = false;
        danhoRealizado = false;
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
