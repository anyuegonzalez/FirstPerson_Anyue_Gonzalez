using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor.Timeline;
using UnityEngine;

public class Granada : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float fuerzaImpulso;
    [SerializeField] float tiempoVida;

    [SerializeField] private LayerMask queEsExplotable;
    [SerializeField] float radioDeteccion;

    [SerializeField] private GameObject explosionPrefab;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * fuerzaImpulso, ForceMode.Impulse);
        Destroy(gameObject, tiempoVida);
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // cuando toques suelo es cuando explota 
    }

    private void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Collider[] collsDetectados = Physics.OverlapSphere(transform.position, radioDeteccion, queEsExplotable);
        if(collsDetectados.Length > 0)
        {
            foreach(Collider collider in collsDetectados)
            {
                collider.GetComponent<EnemyPart>().Explotar(); // desabilito el mov del enemigo impactado
                collider.GetComponent<Rigidbody>().isKinematic = false; // dejo los huesos en dinamico
                collider.GetComponent<Rigidbody>().AddExplosionForce(80, transform.position, radioDeteccion, 15.5f, ForceMode.Impulse); // aplico explosion

            }
        }
        Debug.Log("No puedo mas, me voy de este mundo:(");
    }

}
