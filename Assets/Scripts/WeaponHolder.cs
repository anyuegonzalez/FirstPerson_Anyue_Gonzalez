using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] GameObject[] armas;

    int indiceArmaActual = 0; // en cuanto al array que te refieres
    
    void Start()
    {
        
    }

   
    void Update()
    {
        CambiarArmaConRaton();
        CambiarArmaConTeclado();
    }
    private void CambiarArmaConTeclado()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            CambiarArma(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            CambiarArma(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            CambiarArma(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            CambiarArma(3);
        }
    }
    private void CambiarArmaConRaton()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if(scrollWheel > 0)
        {
            CambiarArma(indiceArmaActual - 1);
        }
        else if(scrollWheel < 0)
        {
            CambiarArma(indiceArmaActual + 1);
        }
    }

    public void CambiarArma(int nuevoIndice)
    {
        
        // solo si es un indice valido puedo cambiar de arma
        if(nuevoIndice >= 0 && nuevoIndice < armas.Length)
        {
            // desactivo el arma que actualmente llevo equipada
            armas[indiceArmaActual].SetActive(false);

            indiceArmaActual = nuevoIndice;
            armas[indiceArmaActual].SetActive(true);
        }
        
    }
}
