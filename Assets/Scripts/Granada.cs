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
    private void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Collider[] collDetectados = Physics.OverlapSphere(transform.position, radioDeteccion, queEsExplotable);
        if(collDetectados.Length > 0)
        {
            
        }
        Debug.Log("No puedo mas, me voy de este mundo:(");
    }

}
