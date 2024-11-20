using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class ArmaAutomatica : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSO misDatos; // scriptableobject

    private Camera cam;
    void Start()
    {
        cam = Camera.main;
        
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            system.Play();
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                if (hitInfo.transform.CompareTag("ParteEnemigo"))
                {
                    hitInfo.transform.GetComponent<EnemyPart>().RecibirDanho(misDatos.danhoAtaque);
                }

            }
        }
        
    }
}
