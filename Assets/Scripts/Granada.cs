using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor.Timeline;
using UnityEngine;

public class Granada : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float fuerzaImpulso;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * fuerzaImpulso, ForceMode.Impulse);
    }
    void Update()
    {
        
    }
}
