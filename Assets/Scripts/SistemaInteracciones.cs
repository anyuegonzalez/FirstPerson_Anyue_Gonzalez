using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{

    private Camera cam;
    [SerializeField] private float distanciaInteraccion;

    private Transform interactuableActual;
    void Start()
    {
        cam = Camera.main;
    }

   
    void Update()
    {
        Debug.Log(cam.name);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distanciaInteraccion)) //forwad para delante
        {
            if (hit.transform.TryGetComponent(out CajaMunicion scripCaja))
            {
                // activar el outline de la caja de municion
                interactuableActual = hit.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    scripCaja.Abrir();
                }
            }
            else if(hit.transform.TryGetComponent(out Npc npc))
            {
                Debug.Log("sdfdsfffffff");
                if(Input.GetKeyDown(KeyCode.E))
                {
                    npc.Interactuar(transform);
                }
            }
        }
        else if(interactuableActual) // si tenia un interactuable pero ya no...
        {
            // le apago...
            interactuableActual.GetComponent<Outline>().enabled = false;

            // le anulo
            interactuableActual = null; // porque no tengo interactuable ya
        }
    }
    
}
