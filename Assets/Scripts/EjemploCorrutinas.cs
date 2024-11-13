using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploCorrutinas : MonoBehaviour
{
    private bool corrutinaAbierta = false;
    void Start()
    {
        StartCoroutine(Semaforo());
        if(Input.GetKeyDown(KeyCode.S) && corrutinaAbierta ==false)
        {
            corrutinaAbierta = true;
        }
    }

    void Update()
    {
        
        
    }
    IEnumerator Semaforo()
    {
        Debug.Log("Verde");
        yield return new WaitForSeconds(2);
        Debug.Log("Amarillo");
        yield return new WaitForSeconds(3);
        Debug.Log("Rojo");
    }
}
