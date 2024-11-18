using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    [SerializeField] private GameObject granadePrefab;
    [SerializeField] private Transform spawnPoint;
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // creo una instancia con la misma orientacion que el cañon 
            Instantiate(granadePrefab, spawnPoint.position, spawnPoint.rotation);

        }
    }
}
