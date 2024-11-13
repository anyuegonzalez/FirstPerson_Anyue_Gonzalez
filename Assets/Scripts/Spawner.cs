using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] puntosSpawn;
    [SerializeField] private Enemigo enemigoPrefab;
    void Start()
    {
        Instantiate(enemigoPrefab, puntosSpawn[0].position, Quaternion.identity);
    }
}
