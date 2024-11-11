using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaManual : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSO misDatos;
    
    private Camera cam;
    void Start()
    {
        //cam es la camara principal de la escena "MainCamera"
        cam = Camera.main;

    }

   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            system.Play();
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                if(hitInfo.transform.CompareTag("ParteEnemigo"))
                {
                    hitInfo.transform.GetComponent<EnemyPart>().RecibirDanho(misDatos.danhoAtaque);
                }
               
            }
        }
    }
}
