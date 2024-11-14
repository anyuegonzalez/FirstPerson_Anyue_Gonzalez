using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] GameObject[] armas;

    int indiceArmaActual = -1; // en cuanto al array que te refieres
    
    void Start()
    {
        
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            CambiarArma(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CambiarArma(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            CambiarArma(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            CambiarArma(3);
        }
    }

    public void CambiarArma(int nuevoIndice)
    {
        armas[indiceArmaActual].SetActive(false);

        indiceArmaActual = nuevoIndice;

        armas[indiceArmaActual].SetActive(true);
    }
}
